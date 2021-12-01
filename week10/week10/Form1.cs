using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week10.Entities;

namespace week10
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rnd = new Random(1234);
        public Form1()
        {
            InitializeComponent();
            Population = ReadPopulation(@"C:\Users\Bela\source\repos\VersionControl_MA\week10\nép-teszt.csv");
            BirthProbabilities = ReadBirthP(@"C:\Users\Bela\source\repos\VersionControl_MA\week10\születés.csv");
            DeathProbabilities = ReadDeathP(@"C:\Users\Bela\source\repos\VersionControl_MA\week10\halál.csv");
            dataGridView1.DataSource = Population;
            dataGridView2.DataSource = BirthProbabilities;
            dataGridView3.DataSource = DeathProbabilities;

            for (int y = 2005; y < 2025; y++)
            {
                for (int i = 0; i < Population.Count; i++)
                {

                    var male = (from a in Population where a.Gender == Gender.Male && a.IsAlive == true select a).Count(); //miért nem tudom listává alakítani?
                    var female = (from b in Population where b.Gender == Gender.Female && b.IsAlive == true select b).Count();
                    Console.WriteLine(String.Format("{0},{1},{2}", y,male,female));
                   
                }

            }
            
        }

        

        private List<Person> ReadPopulation(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    Person p = new Person();
                    p.BirthYear = int.Parse(line[0]);
                    p.Gender = (Gender)Enum.Parse(typeof(Gender), line[1]);
                    p.NoChildren = int.Parse(line[2]);
                    //p.IsAlive = bool.Parse(line[3]);
                    Population.Add(p);
   
                }
            
            
            }

            return Population;
        }

        private List<BirthProbability> ReadBirthP(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default ))
            {
                while (!sr.EndOfStream)
                {
                    string [] line = sr.ReadLine().Split(';');
                    BirthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NoChildren = int.Parse(line[1]),
                        Odds = double.Parse(line[2])



                    });

                }   
 
            }

            return BirthProbabilities;
        }

        private List<DeathProbability> ReadDeathP(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    DeathProbabilities.Add(new DeathProbability()
                    { 

                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                       Age = int.Parse(line[1]),
                       Odds = double.Parse(line[2])
                    
                    
                    
                    });



                }
            
            
            
            
            }



            return DeathProbabilities;
        
        }
    }
}
