using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace luanma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBox2.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(saveFileDialog1.FileName))
                        {
                            FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine(richTextBox1.Text.Trim());
                            sw.Flush();
                            sw.Dispose();
                            sw.Close();
                            fs.Close();
                        }
                        MessageBox.Show("成功保存为文件“" + saveFileDialog1.FileName + "”", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter sw = File.AppendText(openFileDialog1.FileName);
                        sw.WriteLine(richTextBox1.Text.Trim());
                        sw.Close();
                        MessageBox.Show("成功保存为文件“" + openFileDialog1.FileName + "”", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show("NO！\n发生了一个错误！\n原因：" + ex.Message, "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Retry)
                {
                    button4_Click(sender, e);
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    if (!checkBox2.Checked)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if (!File.Exists(saveFileDialog1.FileName))
                            {
                                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite);
                                StreamWriter sw = new StreamWriter(fs);
                                sw.WriteLine(richTextBox1.Text.Trim());
                                sw.Flush();
                                sw.Dispose();
                                sw.Close();
                                fs.Close();
                            }
                            MessageBox.Show("成功保存为文件“" + saveFileDialog1.FileName + "”", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter sw = File.AppendText(openFileDialog1.FileName);
                            sw.WriteLine(richTextBox1.Text.Trim());
                            sw.Close();
                            MessageBox.Show("成功保存为文件“" + openFileDialog1.FileName + "”", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown2.Enabled = true;
            }
            else
            {
                numericUpDown2.Enabled = false;
            }
        }
        Random ran = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                button4.Enabled = false;
                richTextBox1.Text = "";
                if (!radioButton1.Checked)
                {
                    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (checkBox6.Checked)
                    {
                        for (int i2 = 0; i2 < (int)Math.Floor(numericUpDown1.Value / 30); i2++)
                        {
                            richTextBox1.Text += GetRandomChinese(30);
                        }
                        richTextBox1.Text += GetRandomChinese((int)(numericUpDown1.Value - Math.Floor(numericUpDown1.Value / 30) * 30));
                    }
                    for (int i = 1; i < numericUpDown1.Value + 1; i++)
                    {
                        if (checkBox3.Checked)
                        {
                            richTextBox1.Text += characters[ran.Next(characters.Length)];
                        }
                        if (checkBox4.Checked)
                        {
                            richTextBox1.Text += characters[ran.Next(characters.Length)].ToString().ToLower();
                        }
                        if (checkBox5.Checked)
                        {
                            richTextBox1.Text += ran.Next(0, 9);
                        }
                        if (checkBox7.Checked)
                        {
                            richTextBox1.Text += deUnicode("04" + GetRandomHexNumber(2));
                        }
                        if (checkBox8.Checked)
                        {
                            richTextBox1.Text += deUnicode("1" + GetRandomHexNumber(4));
                        }
                        if (checkBox9.Checked)
                        {
                            //richTextBox1.Text += deUnicode("20" + );
                        }
                    }
                }
                else
                {
                    for (int i2 = 0; i2 < numericUpDown1.Value; i2++)
                    {
                        if (ran.Next(0,1) == 0)
                        {
                            richTextBox1.Text += deUnicode(GetRandomHexNumber(5));
                        }
                        else
                        {
                            richTextBox1.Text += deUnicode(GetRandomHexNumber(4));
                        }
                    }
                }
                if (checkBox1.Checked)
                {
                    string str = System.Text.RegularExpressions.Regex.Replace(richTextBox1.Text, @"(?<=\b(.{" + numericUpDown2.Value + "})+)", "$0,");
                    string[] strs = str.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    richTextBox1.Text = String.Join("\n",strs);
                }
                button4.Enabled = true;
            }).Start();
        }
        public static string GetRandomHexNumber(int digits)
        {
            Random random = new Random();
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            System.Threading.Thread.Sleep(1);
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
        public static String deUnicode(String content)
        {
            String enUnicode = null;
            String deUnicode = null;
            for (int i = 0; i < content.Length; i++)
            {

                enUnicode += content[i];

                if (i % 4 == 3)
                {

                    deUnicode += (char)(Convert.ToInt32(enUnicode, 16));


                    enUnicode = null;
                }

            }
            return deUnicode;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制到剪贴板失败！\n原因：" + ex.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button4.Text = "保存为文件（追加）";
            }
            else
            {
                button4.Text = "保存为文件";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2(richTextBox1.Text).ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                return;
            }
            checkBox1.Checked = true;
        }
        public string GetRandomChinese(int strlength)
        {
            // 获取GB2312编码页（表）
            Encoding gb = Encoding.GetEncoding("gb2312");

            object[] bytes = this.CreateRegionCode(strlength);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strlength; i++)
            {
                string temp = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                sb.Append(temp);
            }

            return sb.ToString();
        }
        private object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            Random rnd = new Random();

            //定义一个object数组用来
            object[] bytes = new object[strlength];

            /**
             每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bytes数组中
             每个汉字有四个区位码组成
             区位码第1位和区位码第2位作为字节数组第一个元素
             区位码第3位和区位码第4位作为字节数组第二个元素
            **/
            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i); // 更换随机数发生器的 种子避免产生重复值
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                // 定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                // 将两个字节变量存储在字节数组中
                byte[] str_r = new byte[] { byte1, byte2 };

                // 将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(str_r, i);
            }

            return bytes;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
            }
            else
            {
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
            }
        }
    }
}