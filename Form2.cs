using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luanma
{
    public partial class Form2 : Form
    {
        string s = "";
        public Form2(string s)
        {
            InitializeComponent();
            this.s = s;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = s;
        }
    }
}
