using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;
using week08.Entites;

namespace week08
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private Toy _netToy;
        private IToyFactory _factory; // Ez micsoda? 
        
        private IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                Display();
            }
        }
       
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
            label1.Text = "Coming Next";
            button1.Text = "CAR";
            button2.Text = "BALL";

            
            
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var Toy = Factory.CreateNew();
            _toys.Add(Toy);

            Toy.Left = -1 * Toy.Width;
            mainPanel.Controls.Add(Toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxposition = 0;
            foreach (var Toy in _toys)
            {
                Toy.MoveToy();
                if (Toy.Left > maxposition)
                {
                    maxposition = Toy.Left;
                }

            }
            if (maxposition > 1000)
            {
                var elso = _toys[0];
                _toys.Remove(elso);
                mainPanel.Controls.Remove(elso);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                Ballcolor = button3.BackColor

        };
            
        }


        private void Display()
        {
            if (_netToy !=null)
            {
                Controls.Remove(_netToy);
                _netToy = Factory.CreateNew();
                _netToy.Left = label1.Left + 20;
                _netToy.Top = label1.Top + 10;


                Controls.Add(_netToy);
                
            }
        
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Fuchsia;
            var button = (Button)sender;
            ColorDialog crd = new ColorDialog();
            crd.Color = button3.BackColor;
            if (crd.ShowDialog()!= DialogResult.OK)
            {
                return;
            }
            else
            {
                button3.BackColor = crd.Color;
            }
        }
    }
}
