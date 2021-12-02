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
            Population = ReadPopulation(@"C:\Users\Bela\source\repos\week10_adatok\nép-teszt.csv");
            BirthProbabilities = ReadBirthP(@"C:\Users\Bela\source\repos\week10_adatok\születés.csv");
            DeathProbabilities = ReadDeathP(@"C:\Users\Bela\source\repos\week10_adatok\halál.csv");
            dataGridView1.DataSource = Population;
            dataGridView2.DataSource = BirthProbabilities;
            dataGridView3.DataSource = DeathProbabilities;
            Simulation();

        }

        public void Simulation()
        {
            for (int y = 2005; y < numericUpDown1.Value; y++)
            {
                for (int i = 0; i < Population.Count; i++)
                {

                    SimStep(y, Population[i]);

                }

                var male = (from a in Population where a.Gender == Gender.Male && a.IsAlive == true select a).Count(); //miért nem tudom listává alakítani?
                var female = (from b in Population where b.Gender == Gender.Female && b.IsAlive == true select b).Count();


                Console.WriteLine(String.Format("Év: {0}, Fiúk {1},Lányok {2}", y, male, female));
            }
        }

        public void SimStep(int year, Person person)
        {

            if (person.IsAlive == false)
            {
                return;
            }

            
            var age = year - person.BirthYear;
            double death_p = (from x in DeathProbabilities where x.Gender == person.Gender && x.Age == age select x.Odds).FirstOrDefault();

            if (rnd.NextDouble() <= death_p)
            {
                person.IsAlive = false;
            }
            if (person.Gender == Gender.Female && person.IsAlive )
            {
                var birth_p = (from z in BirthProbabilities where z.Age == age select z.Odds).FirstOrDefault();
                double randomszam = rnd.Next(0, 1);
                if (birth_p > rnd.NextDouble())
                {
                    Person újp = new Person();               
                    int randomnem = rnd.Next(1, 3);
                    újp.Gender = (Gender)randomnem;
                    újp.BirthYear = year;
                    újp.NoChildren = 0;
                    újp.IsAlive = true;
                    Population.Add(újp);


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

        private void button1_Click(object sender, EventArgs e)
        {
            Simulation();
        }


    }
}
