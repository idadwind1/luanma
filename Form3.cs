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
    public partial class Form3 : Form
    {
        public bool[] bools = new bool[7];

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel) return;
            for (int i = 0; i < bools.Length; i++) bools[i] = checkedListBox1.GetItemChecked(i);
        }

        public Form3(bool[] bools)
        {
            InitializeComponent();
            this.bools = bools;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < bools.Length; i++) checkedListBox1.SetItemChecked(i, bools[i]);
        }
    }
}
