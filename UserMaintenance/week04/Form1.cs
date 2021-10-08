using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week04
{
    public partial class Form1 : RealEstateEntities


    {


        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;




        public Form1()
        {
            InitializeComponent();
            LoadData();
            //using Excel = Microsoft.Office.Interop.Excel;
            //using system.Reflection;
        }

        private void LoadData()
        {

            Flats = context.Flats.ToList();
            

        }
    }
}
