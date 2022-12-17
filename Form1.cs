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
using System.Threading;

namespace luanma
{
    public partial class Form1 : Form
    {
        Thread thread;
        bool[] bools = new bool[15];
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly Dictionary<char, string[]> words = new Dictionary<char, string[]>()
        {
            { 'a',new string[] { "ä", "ā", "á", "ǎ", "à", "ă", "å", "ǻ", "ǟ", "ǡ", "ǻ", "ȁ", "ȃ", "ȧ", "ᶏ", "ḁ", "ẚ", "ạ", "ả", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ắ", "ằ", "ẳ", "ẵ", "ặ", "ɑ", "α", "ά", "ὰ", "ἀ", "ἁ", "ἂ", "ἃ", "ἆ", "ἇ", "ᾂ", "ᾃ", "ᾰ", "ᾱ", "ᾲ", "ᾳ", "ᾴ", "ᾶ", "ᾷ", "ⱥ", "𐓘", "𐓙", "𐓚" } },
            { 'A',new string[] { "Ā", "Á", "Ǎ", "À", "Â", "Ã", "Ä", "Å", "Ǻ", "Ά", "Ă", "Δ", "Λ", "Д", "Ą" } },
            { 'b',new string[] { "b", "ь", "в", "Ъ", "Б", "б", "β", "ƀ", "ƃ", "ɓ", "ᵬ", "ᶀ", "ḃ", "ḅ", "ḇ", "ꞗ" } },
            { 'B',new string[] { "ß", "฿" } },
            { 'c',new string[] { "ç", "ς", "ĉ", "č", "ċ", "ć", "ĉ", "ċ", "ƈ", "ȼ", "¢", "ɕ", "ḉ", "ꞓ", "ꞔ" } },
            { 'C',new string[] { "Č", "Ç", "Ĉ", "Ć", "€" } },
            { 'd',new string[] { "d", "ď", "đ", "₫", "ð", "δ" } },
            { 'D',new string[] { "Ď", "Ð" } },
            { 'e',new string[] { "ē", "é", "ě", "è", "ê", "ĕ", "ė", "ë", "ę", "з", "ε", "έ", "э", "℮" } },
            { 'E',new string[] { "Ē", "É", "Ě", "È", "Ĕ", "Ё", "Σ", "Έ", "Є", "Э", "З" } },
            { 'f',new string[] { "ƒ" } },
            { 'F',new string[] { "₣" } },
            { 'g',new string[] { "ḡ", "ģ", "ǧ", "ĝ", "ğ", "ġ", "ǥ", "ǵ", "ɠ", "ᶃ", "ꞡ" } },
            { 'G',new string[] { "Ḡ", "Ǵ", "Ǧ", "Ĝ", "Ğ", "Ģ", "Ġ", "Ɠ", "Ǥ", "Ꞡ" } },
            { 'h',new string[] { "ĥ", "ħ", "ђ", "н" } },
            { 'H',new string[] { "Ĥ", "Ħ" } },
            { 'i',new string[] { "ı", "ī", "í", "ǐ", "ì", "ĭ", "î", "ï", "ί", "į", "ΐ" } },
            { 'I',new string[] { "Ī", "Í", "Ǐ", "Ì", "Î", "Ï", "Ĭ", "Ί" } },
            { 'j',new string[] { "j" } },
            { 'J',new string[] { "Ĵ" } },
            { 'k',new string[] { "ƙ", "κ" } },
            { 'K',new string[] { "К" } },
            { 'l',new string[] { "ŀ", "ļ", "ℓ", "ĺ", "ļ", "ľ", "ł", "ι" } },
            { 'L',new string[] { "Ŀ", "£", "Ļ", "Ł", "Ĺ" } },
            { 'm',new string[] { "₥", "м" } },
            { 'M',new string[] { "M" } },
            { 'n',new string[] { "ń", "ň", "ŉ", "η", "ή", "и", "й", "ñ", "л", "п", "π" } },
            { 'N',new string[] { "Ń", "Ň", "И", "Й", "Π", "Л" } },
            { 'o',new string[] { "ō", "ó", "ŏ", "ò", "ô", "õ", "ö", "ő", "σ", "ø", "ǿ" } },
            { 'O',new string[] { "Ō", "Ó", "Ǒ", "Ò", "Ô", "Õ", "Ö", "Ό", "Θ", "Ǿ" } },
            { 'p',new string[] { "ρ", "ƥ", "φ" } },
            { 'P',new string[] { "Þ", "₽" } },
            { 'q',new string[] { "ʠ", "ɋ" } },
            { 'Q',new string[] { "Ɋ" } },
            { 'r',new string[] { "ř", "ŗ", "г", "ѓ", "ґ", "я" } },
            { 'R',new string[] { "Ř", "Я", "Г", "Ґ" } },
            { 's',new string[] { "ś", "š", "ŝ", "ș", "ş", "ƨ" } },
            { 'S',new string[] { "Š", "Ş", "Ș", "§" } },
            { 't',new string[] { "ț", "ţ", "ť", "ŧ", "т", "τ" } },
            { 'T',new string[] { "Ť", "Ţ", "Ț", "Ŧ" } },
            { 'u',new string[] { "ū", "ú", "ǔ", "ù", "û", "ũ", "ů", "ų", "ü", "ǖ", "ǘ", "ǚ", "ǜ", "ύ", "ϋ", "ΰ", "µ", "ц", "џ" } },
            { 'U',new string[] { "Ū", "Ǔ", "Ǖ", "Ǘ", "Ǚ", "Ǜ", "Ц" } },
            { 'v',new string[] { "ν" } },
            { 'V',new string[] { "Ṽ", "Ṿ", "Ꝟ" } },
            { 'w',new string[] { "ẃ", "ẁ", "ẅ", "ŵ", "ш", "щ", "ω", "ώ" } },
            { 'W',new string[] { "Ẁ", "Ẃ", "Ẅ", "Ŵ", "Ш", "Щ" } },
            { 'x',new string[] { "ж" } },
            { 'X',new string[] { "Ж" } },
            { 'y',new string[] { "ỳ", "ŷ", "ч", "γ" } },
            { 'Y',new string[] { "Ϋ", "Ÿ", "Ŷ", "Ỳ", "Ύ", "Ψ", "￥", "У", "Ў", "Ч" } },
            { 'z',new string[] { "ź", "ż", "ž", "ƶ", "ȥ", "ʐ", "ᵶ", "ᶎ", "ẑ", "ẓ", "ẕ", "ⱬ" } },
            { 'Z',new string[] { "Ź", "Ż", "Ž", "Ƶ", "Ȥ", "Ẓ", "Ẕ", "Ẑ", "Ⱬ" } }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Main()
        {
            try
            {
                button1.Enabled = false;
                button6.Enabled = true;
                tabControl1.Enabled = false;
                progressBar1.Value = 0;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                checkBox1.Enabled = false;
                richTextBox1.Text = "";
                if (tabControl1.SelectedIndex == 0)
                {
                    if (!radioButton1.Checked)
                    {
                        List<int> ints = new List<int>();
                        foreach (Control control in panel1.Controls)
                        {
                            if (control is CheckBox && (control as CheckBox).Checked)
                            {
                                CheckBox checkBox = (CheckBox)control;
                                ints.Add(int.Parse(checkBox.Name.Replace("c", string.Empty)) - 1);
                            }
                        }
                        for (int i = 0; i < bools.Length - 1; i++) if (bools[i]) ints.Add(i + 8);
                        double probar = 0d;
                        for (int i = 0; i < numericUpDown1.Value; i++)
                        {
                            //if (!c1.Checked && !c2.Checked && !c3.Checked && !c4.Checked && !c5.Checked && !c6.Checked && !c7.Checked && !c8.Checked && !a && !b && !c && !d && !this.e && !f && !g && !h) break;
                            Thread.Sleep(10);
                            GenerateChars(ints);
                            probar += 100 / (double)numericUpDown1.Value;
                            progressBar1.Value = (int)probar;
                        }
                    }
                    else
                    {
                        double probar = 0d;
                        for (int i2 = 0; i2 < numericUpDown1.Value; i2++)
                        {
                            if (ran.Next(0, 1) == 0)
                            {
                                richTextBox1.Text += deUnicode(GetRandomHexNumber(5));
                            }
                            else
                            {
                                richTextBox1.Text += deUnicode(GetRandomHexNumber(4));
                            }
                            probar += 100 / (double)numericUpDown1.Value;
                            progressBar1.Value = (int)probar;
                        }
                    }
                    if (checkBox1.Checked)
                    {
                        string str = System.Text.RegularExpressions.Regex.Replace(richTextBox1.Text, @"(?<=\b(.{" + numericUpDown2.Value + "})+)", "$0,");
                        string[] strs = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        richTextBox1.Text = String.Join("\n", strs);
                    }
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    if (checkBox12.Checked) richTextBox1.Text += "[";
                    double probar = 0d;
                    foreach (char c in richTextBox2.Text)
                    {
                        try { richTextBox1.Text += words[c][ran.Next(words[c].Length)]; }
                        catch (KeyNotFoundException) { richTextBox1.Text += c; }
                        probar += (double)100 / richTextBox2.Text.Length;
                        progressBar1.Value = (int)probar;
                    }
                    if (checkBox13.Checked)
                    {
                        richTextBox1.Text += " ";
                        string[] spl = richTextBox2.Text.Split(' ');
                        for (int i = 0; i < spl.Length; i++)
                        {
                            if (i % 4 == 0)
                            {
                                richTextBox1.Text += " ";
                                continue;
                            }
                            richTextBox1.Text += "!";
                        }
                    }
                    if (checkBox12.Checked) richTextBox1.Text += "]";
                }
            }
            catch (ThreadAbortException)
            {
                MessageBox.Show("进程被用户终止", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误!\n原因: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                checkBox1.Enabled = true;
                progressBar1.Value = 100;
                tabControl1.Enabled = true;
                button6.Enabled = false;
                button1.Enabled = true;
            }

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
            thread = new Thread(new ThreadStart(Main));
            thread.Start();
        }

        public string GetRandomArrows()
        {
            switch (new Random().Next(0,3))
            {
                case 0:
                    return deUnicode(GetRandomHexNumberEx(0x27F0,0x27FF));
                case 1:
                    return deUnicode(GetRandomHexNumberEx(0x2900,0X297F));
                case 2:
                    return deUnicode(GetRandomHexNumberEx(0x2B00,0x2BFF));
                case 3:
                    return deUnicode(GetRandomHexNumberEx(0x2190,0x21FF));
                default:return "";
            }
        }

        public static string GetRandomHexNumber(int digits)
        {
            Random random = new Random();
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            Thread.Sleep(1);
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        private void GenerateChars(List<int> ids)
        {
            if (ids.Count == 0) return;
            switch (ids[new Random().Next(0, ids.Count)])
            {
                case 0: richTextBox1.Text += characters[ran.Next(characters.Length)];break;
                case 1: richTextBox1.Text += characters[ran.Next(characters.Length)].ToString().ToLower();break;
                case 2: richTextBox1.Text += ran.Next(0, 9); break;
                case 3: richTextBox1.Text += GetRandomChinese(1); break;
                case 4: richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x0400, 0x052F)); break;
                case 5: richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x10000,0x1FFFF,5));break;
                case 6: richTextBox1.Text += "";/*if (checkBox9.Checked) richTextBox1.Text += deUnicode("20" + );*/break;
                case 7: richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x3040, 0x30FF)); break;
                case 8: richTextBox1.Text += "";break;
                case 9: richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x2800,0x28FF));break;
                case 10:richTextBox1.Text += "Math";break;
                case 11:richTextBox1.Text += "";break;
                case 12:richTextBox1.Text += "";break;
                case 13:richTextBox1.Text += "";break;
                case 14:richTextBox1.Text += "";break;
                case 15:richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x3100,0x312F));break;
                case 16:richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x2300,0x23FF));break;
                case 17:richTextBox1.Text += GetRandomArrows();break;
                case 18:richTextBox1.Text += "";break;
                case 19:richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x2500, 0x257F));break;
                case 20:richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x2580, 0x259F));break;
                case 21:richTextBox1.Text += "";break;
                case 22:richTextBox1.Text += "";break;
                default:richTextBox1.Text += "错误!找不到生成参数\n";throw new ArgumentException("找不到生成选项");
            }
        }

        public static string deUnicode(string content)
        {
            string enUnicode = null;
            string deUnicode = null;
            for (int i = 0; i < content.Length; i++)
            {
                enUnicode += content[i];
                if (i % 4 == 3)
                {
                    deUnicode += (char)Convert.ToInt32(enUnicode, 16);
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
                c1.Enabled = false;
                c2.Enabled = false;
                c3.Enabled = false;
                c4.Enabled = false;
                c5.Enabled = false;
                c6.Enabled = false;
                c7.Enabled = false;
                c8.Enabled = false;
                button5.Enabled = false;
                return;
            }
            c1.Enabled = true;
            c2.Enabled = true;
            c3.Enabled = true;
            c4.Enabled = true;
            c5.Enabled = true;
            c6.Enabled = true;
            c7.Enabled = true;
            c8.Enabled = true;
            button5.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*new Task(() =>
            {
                while (true)
                {
                }
            }).Start();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(bools);
            form3.ShowDialog();
            for (int i = 0; i < bools.Length; i++) bools[i] = form3.bools[i];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button6.Text = "取消中...";
            thread.Abort();
            thread.Join();
            button6.Text = "取消";
        }

        public string GetRandomHexNumberEx(int minValue,int maxValue, int length = 4)
        {
            return Convert.ToString(new Random().Next(int.Parse(Convert.ToString(minValue, 10)), int.Parse(Convert.ToString(maxValue, 10))), 16).PadLeft(length, '0');
        }
    }
}