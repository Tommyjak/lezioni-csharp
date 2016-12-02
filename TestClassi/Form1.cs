using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MortaraMonster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
           
        private void Form1_Load(object sender, EventArgs e)
        {
            Monster strongbonna = new Monster("Strongbonna", 10, 50, textBox1);
            Monster charmender = new Monster("Charmender", 56, 10, textBox1, 10);
            strongbonna.attack(charmender, textBox1);
            charmender.attack(strongbonna, textBox1);
            charmender.heal(charmender, textBox1);
        }
    }
}
