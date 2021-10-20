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
using week05.Entites;

namespace week05
{


    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> ticks;
        List<PortfolioItem> portfoliolista = new List<PortfolioItem>();
        List<decimal> nyer = new List<decimal>();
        public Form1()
        {
            InitializeComponent();
            CreatePortfolio();
            ticks = context.Ticks.ToList(); // A context-et bele rakjuk a ticks listába
                                            //a. Portfóliónk elemszáma:
            int elemszám = portfoliolista.Count();
            //A Count() bálrmilyen megszámlálható listára alkalmazható.

            //b. A portfólióban szereplő részvények darabszáma: 
            decimal részvényekSzáma = (from x in portfoliolista select x.volume).Sum();
            MessageBox.Show(string.Format("Részvények száma: {0}", részvényekSzáma));
            //Először egy listába kigyűjtjük csak a darabszámokat, majd az egész bezárójlezett listát summázzuk. 
            //(A zárójelben lévő LINQ egy int-ekből álló listát ad, mert a Count tulajdonság int típusú.)
            //Működik a Min(), Max(), Average(), stb. is.

            //c. A legrégebbi kereskedési nap:
            DateTime minDátum = (from x in ticks select x.TradingDay).Min();

            //d. A legutolsó kereskedési nap:
            DateTime maxDátum = (from x in ticks select x.TradingDay).Max();

            //e. A két dátum közt eltelt idő napokban -- két DateTime típusú objektum különbsége TimeSpan típusú eredményt ad.
            //A TimeSpan Day tulajdonsága megadja az időtartam napjainak számát. (Nem kell vacakolni a szökőévekkel stb.)
            int elteltNapokSzáma = (maxDátum - minDátum).Days;

            //f. Az OTP legrégebbi kereskedési napja: 
            DateTime optMinDátum = (from x in ticks where x.Index == "OTP" select x.TradingDay).Min();

            //g. Össze is lehet kapcsolni dolgokat, ez már bonyolultabb:
            var kapcsolt =
                from
                x in ticks
                join
                y in portfoliolista
                on x.Index equals y.index
                select new
                {
                    Index = x.Index,
                    Date = x.TradingDay,
                    Value = x.Price,
                    Volume = y.volume
                };
            dataGridView1.DataSource = kapcsolt.ToList();



            List<decimal> Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }



            var nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                            .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());
            nyer = nyereségekRendezve;
        }

        private void CreatePortfolio()
        {

            portfoliolista.Add(new PortfolioItem() { index = "OTP", volume = 10 });
            portfoliolista.Add(new PortfolioItem() { index = "ZWACK", volume = 10 });
            portfoliolista.Add(new PortfolioItem() { index = "ELMU", volume = 10 });

            dataGridView2.DataSource = portfoliolista;


        }


        private decimal GetPortfolioValue(DateTime date)
        {

            decimal value = 0;
            foreach (var item in portfoliolista)
            {
                var last = (from x in ticks where item.index == x.Index.Trim() && date <= x.TradingDay select x).First();
                value += (decimal)last.Price * item.volume;
               
            }

            return value;
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // csak a txt fájlokat látod 
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;

            }
            else
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("Időszak\t Nyereség");
                    for (int i = 0; i <  nyer.Count; i++)
                    {
                        sw.WriteLine("{0}\t {1}", i, nyer[i]);
                    }
                
                }

            }

            
        }
    }
}
