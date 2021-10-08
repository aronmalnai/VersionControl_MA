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
                string hiba = string.Format("Error: {0}\nline: {1} ", ex.Message, ex.Source );
                
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



        }


    }
}
