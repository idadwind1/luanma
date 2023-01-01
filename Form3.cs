using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luanma
{
    public partial class Form3 : Form
    {
        public bool[] bools = new bool[8];
        public Form1.RandomArgs WordsInSentence;
        public bool CapsAtFront, AddPeriod,AddfullPeriod;
        public Form1.RandomArgs Space = new Form1.RandomArgs();
        public Form1.RandomArgs Return = new Form1.RandomArgs();

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel) return;
            if (checkBox5.Checked && !radioButton1.Checked && !radioButton2.Checked) { MessageBox.Show("请选择全角或半角句号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); e.Cancel = true; }
            for (int i = 0; i < bools.Length; i++) bools[i] = checkedListBox1.GetItemChecked(i);
            Space.Enabled = checkBox1.Checked;
            Space.Max = (int)numericUpDown2.Value;
            Space.Mini = (int)numericUpDown1.Value;
            Return.Enabled = checkBox3.Checked;
            Return.Max = (int)numericUpDown3.Value;
            Return.Mini = (int)numericUpDown4.Value;
            CapsAtFront = checkBox4.Checked;
            AddPeriod = checkBox5.Checked;
            AddPeriod = radioButton1.Checked && checkBox5.Checked;
            AddfullPeriod = radioButton2.Checked && checkBox5.Checked;
            WordsInSentence.Max = (int)numericUpDown5.Value;
            WordsInSentence.Mini = (int)numericUpDown6.Value;
        }

        public Form3(bool[] bools,Form1.RandomArgs Space, Form1.RandomArgs Return, bool enabledCheckBoxes, bool CapsAtFront, bool AddPeriod, bool AddfullPeriod, Form1.RandomArgs wordsInSentence)
        {
            InitializeComponent();
            this.bools = bools;
            this.Space = Space;
            this.Return = Return;
            this.AddfullPeriod = AddfullPeriod;
            this.AddPeriod = AddPeriod;
            this.CapsAtFront = CapsAtFront;
            checkedListBox1.Enabled = enabledCheckBoxes;
            WordsInSentence = wordsInSentence;
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
            Size = new Size(345, 188);
            for (int i = 0; i < bools.Length; i++) checkedListBox1.SetItemChecked(i, bools[i]);
            checkBox1.Checked = Space.Enabled;
            checkBox3.Checked = Return.Enabled;
            numericUpDown2.Value = Space.Max;
            numericUpDown1.Value = Space.Mini;
            numericUpDown3.Value = Return.Max;
            numericUpDown4.Value = Return.Mini;
            checkBox1_CheckedChanged(sender,e);
            checkBox3_CheckedChanged(sender, e);
            checkBox4.Checked = CapsAtFront;
            checkBox5.Checked = AddPeriod || AddfullPeriod;
            radioButton1.Checked = AddPeriod;
            radioButton2.Checked = AddfullPeriod;
            numericUpDown6.Value = WordsInSentence.Mini;
            numericUpDown5.Value = WordsInSentence.Max;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Size = new Size(538, 308);
                groupBox1.Visible = true;
                groupBox2.Visible = true;
            }
            else
            {
                Size = new Size(345, 188);
                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                MessageBox.Show("最小空行数不能小于最大空行数，运行时将会引起错误！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value > numericUpDown3.Value)
            {
                MessageBox.Show("最小空行数不能小于最大空行数，运行时将会引起错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown6.Value > numericUpDown5.Value)
            {
                MessageBox.Show("最小空行数不能小于最大空行数，运行时将会引起错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }
            else
            {
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
        }
    }
}
