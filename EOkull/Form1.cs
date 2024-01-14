using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOkull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmVeliGirisii fr = new FrmVeliGirisii();
            fr.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgretmenGirisii fr = new FrmOgretmenGirisii();
            fr.Show();
            
        }
    }
}
