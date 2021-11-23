using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week06.MNBServiceReference;
using week06.Entites;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace week06
{
    public partial class Form1 : Form
    {
        
        BindingList<Entites.RateData> rates = new BindingList<RateData>();
        BindingList<string> currencies = new BindingList<string>();
        
        
        public Form1()
        {
            InitializeComponent();
            getCurrencies();
            RefreshData();
            

        }



        private void getCurrencies()
        {
            
            MNBArfolyamServiceSoapClient mnbservice = new MNBArfolyamServiceSoapClient();
            GetCurrenciesRequestBody request = new GetCurrenciesRequestBody();
            var response = mnbservice.GetCurrencies(request);
            var result = response.GetCurrenciesResult;
            MessageBox.Show(result);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            
            foreach (XmlElement item in xml.DocumentElement.ChildNodes[0])
            {
                //var childnotes = (XmlElement)item.ChildNodes[0];
                //string curr2 = childnotes.GetAttribute("curr"); Ez a másik verzió
                string curr = item.InnerText;
                currencies.Add(curr);    
            }

 
            comboBox1.DataSource = currencies;
            File.WriteAllText("result.xml", result);


        }

        private void RefreshData()
        {

            rates.Clear();
            string proba = getExchangeRates(); // eltároltuk a függvény értékét egy változóba- kihoztuk a függvény visszatérési értékét
            getXML(proba); // bemenetként megadtuk az értéket
            dataGridView1.DataSource = rates;
            chartRateData.DataSource = rates;
            var chart_tomb = chartRateData.Series[0];
            chart_tomb.ChartType = SeriesChartType.Line;
            chart_tomb.XValueMember = "date";
            chart_tomb.YValueMembers = "value";
            chart_tomb.BorderWidth = 2;
            chartRateData.Legends[0].Enabled = false;
            chartRateData.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRateData.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartRateData.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }

        private string getExchangeRates()
         {
            MNBArfolyamServiceSoapClient mnbservice = new MNBArfolyamServiceSoapClient();

            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();

            request.currencyNames = (string)comboBox1.SelectedItem;
            request.startDate = dateTimePicker1.Value.ToString();
            request.endDate = dateTimePicker2.Value.ToString();
            var response = mnbservice.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result; // result lesz a függvény visszatérési értéke

        }


        private void getXML(string proba)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(proba);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData rd = new RateData(); //létrehoztunk egy példányt
                
                rd.date = DateTime.Parse(item.GetAttribute("date"));
                var child = (XmlElement)item.ChildNodes[0];
                if (child == null)
                    continue;
                //rd.currency = child.GetAttribute("curr");
                rd.currency = ((XmlElement)item.ChildNodes[0]).GetAttribute("curr");

                if (decimal.Parse(child.GetAttribute("unit")) != 0)
                    rd.value = decimal.Parse(child.InnerText) / decimal.Parse(child.GetAttribute("unit"));

                rates.Add(rd);
            }
        
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
