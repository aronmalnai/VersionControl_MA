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
        List<DeathProbability> deathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();
            Population = ReadPopulation(@"C:\Users\Bela\source\repos\VersionControl_MA\week10\nép.csv");
            BirthProbabilities = ReadBirthP("");
            DeathProbability = ReadDeathP("");
        }


        private void ReadPopulation(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split();
                    Person p = new Person();
                    p.BirthYear = int.Parse(line[0]);
                    p.Gender = (Gender)Enum.Parse(typeof(Gender), line[1]);
                    p.NoChildren = int.Parse(line[2]);
                    //p.IsAlive = bool.Parse(line[3]);
                    Population.Add(p);

                }
            
            
            }
        
        
        }

        private List<BirthProbability> ReadBirthP(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath ))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split();
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

        private void ReadDeathP(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split();
                    deathProbabilities.Add(new DeathProbability()
                    { 

                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                       Age = int.Parse(line[1]),
                       Odds = double.Parse(line[2])
                    
                    
                    
                    });



                }
            
            
            
            
            }
        
        
        
        
        
        }
    }
}
