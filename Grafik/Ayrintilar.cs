using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafik
{
    public partial class Ayrintilar : Form
    {
        public Ayrintilar()
        {
            InitializeComponent();
        }
        
        
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AnaSayfa.dt1;
            label1.Text = AnaSayfa.yazi;
        }

        
    }
}
