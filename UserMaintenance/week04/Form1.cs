using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace week04
{
    public partial class Form1 : Form


    {


        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        Excel.Application xlApp;
        Excel.Workbook xlWb;
        Excel.Worksheet xlWs;





        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
            CreateTable();



        }

        public void LoadData()
        {

            Flats = context.Flats.ToList();


        }

        public void CreateExcel()

        {
            try
            {
                xlApp = new Excel.Application();
                xlWb = xlApp.Workbooks.Add(Missing.Value); //létrehoztunk egy üres munkafüzetet
                xlWs = xlWb.ActiveSheet;


                xlApp.Visible = true; //átadjuk, láthatóvá teszzük a felhasználónak
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string hiba = string.Format("Error: {0}\nline: {1} ", ex.Message, ex.Source);

                xlWb.Close(false, Type.Missing, Type.Missing); //ez itt miért type missing? 
                xlApp.Quit();
                xlApp = null;
            }
            //finally //cath hiba esetén is lefut
            //{ 

            //}

        }

        public void CreateTable()
        {
            
            string[] headers = new string[]
            {

                     "Kód",
                     "Eladó",
                     "Oldal",
                     "Kerület",
                     "Lift",
                     "Szobák száma",
                     "Alapterület (m2)",
                     "Ár (mFt)",
                     "Négyzetméter ár (Ft/m2)",

            };

            for (int i = 0; i < headers.Length; i++)
            {
                xlWs.Cells[1, i +1] = headers[i];

                object[,] values = new object[Flats.Count, headers.Length];
                int counter = 0;
                foreach (var lakas in Flats)
                {
                    values[counter, 0] = lakas.Code;
                    values[counter, 1] = lakas.Vendor;
                    values[counter, 2] = lakas.Side;
                    values[counter, 3] = lakas.District;
                    if (lakas.Elevator == true)
                    { values[counter, 4] = "Van"; }               
                    else
                    { values[counter, 4] = "Nincs"; }


                    values[counter, 4] = lakas.Elevator;
                    values[counter, 5] = lakas.NumberOfRooms;
                    values[counter, 6] = lakas.FloorArea;
                    values[counter, 7] = lakas.Price;
                    values[counter, 8] = "=H2/G2*1000000";  







                    counter++;
                }

                var range =  xlWs.get_Range(GetCell(2, 1), GetCell(1 + values.GetLength(0), values.GetLength(1)));
                range.Value2 = values;


            }

        }


        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }


    }
}
