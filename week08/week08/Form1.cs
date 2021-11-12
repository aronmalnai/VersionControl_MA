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
            set
            {
                _factory = value;
                Display();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory { Ballcolor = Color.Blue };
            label1.Text = "Coming Next";
            button1.Text = "CAR";
            button2.Text = "BALL";



        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var newToy = Factory.CreateNew();
            _toys.Add(newToy);

            newToy.Left = -1 * newToy.Width;
            mainPanel.Controls.Add(newToy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxposition = 0;
            foreach (var newToy in _toys)
            {
                newToy.MoveToy();
                if (newToy.Left > maxposition)
                {
                    maxposition = newToy.Left;
                }

            }
            if (maxposition > 1000)
            {
                var elso = _toys[0];
                mainPanel.Controls.Remove(elso);
                _toys.Remove(elso);
                
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
            if (_netToy != null)
                Controls.Remove(_netToy);
            _netToy = Factory.CreateNew();
            _netToy.Top = label1.Top + label1.Height + 20;
            _netToy.Left = label1.Left;
            Controls.Add(_netToy);


        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            var button = (Button)sender;
            ColorDialog crd = new ColorDialog();
            crd.Color = button.BackColor;
            if (crd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button.BackColor = crd.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory
            {
                color1 = button5.BackColor,
                color2 = button6.BackColor
                


            };

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            var button = (Button)sender;
            ColorDialog crd = new ColorDialog();
            crd.Color = button.BackColor;
            if (crd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button.BackColor = crd.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog crd = new ColorDialog();
            crd.Color = button.BackColor;
            if (crd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button.BackColor = crd.Color;
            }
        }
    }
}
