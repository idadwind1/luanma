﻿using System;
using System.Collections.Generic;
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
        /// <summary>
        /// ProgressBar.Value存的是int，自己定义一个double用来定义带小数点的ProgressBar.Value
        /// </summary>
        static public double probar = 0;

        /// <summary>
        /// 窗体是否关闭
        /// </summary>
        bool IsClosed = false;

        /// <summary>
        /// 一句话里有几个字母
        /// </summary>
        RandomArgs Sentence = new RandomArgs();

        /// <summary>
        /// 启动Main的线程
        /// </summary>
        static public Thread thread;

        /// <summary>
        /// 每个CheckBox的选择情况
        /// </summary>
        bool[] bools = new bool[18];

        /// <summary>
        /// 是否在句首添加大写字母
        /// </summary>
        bool CapsAtFront = false;
        /// <summary>
        /// 是否在句尾添加句号
        /// </summary>
        bool AddPeriod = false;
        /// <summary>
        /// 是否在句尾添加句号（全角）
        /// </summary>
        bool AddfullPeriod = false;

        /// <summary>
        /// 随机生成的参数类
        /// Max: 最大
        /// Mini: 最小
        /// Enabled: 是否启用
        /// </summary>
        public class RandomArgs
        {
            public int Max;
            public int Mini;
            public bool Enabled;
        }

        /// <summary>
        /// 后面用来生成字母用的
        /// </summary>
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
        RandomArgs Space = new RandomArgs();
        RandomArgs Return = new RandomArgs();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始进程时的时间
        /// </summary>
        static public DateTime StartTime;

        /// <summary>
        /// 主生成函数，使用多线程启动
        /// </summary>
        private void Main()
        {
            StartTime = DateTime.Now;
            try
            {
                info("运行中");
                TaskbarManager1.SetProgressState(TaskbarProgressBarState.Normal);
                取消生成CToolStripMenuItem.Enabled = 取消生成ToolStripMenuItem.Enabled = toolStripStatusLabel2.Visible = toolStripProgressBar1.Visible = button6.Enabled = true;
                probar = toolStripProgressBar1.Value = progressBar1.Value = 0;
                开始SToolStripMenuItem.Enabled = 开始生成ToolStripMenuItem.Enabled = numericUpDown1.Enabled = numericUpDown2.Enabled = checkBox1.Enabled = tabControl1.Enabled = button1.Enabled = false;
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
                        for (int i = 0; i < bools.Length; i++) if (bools[i]) ints.Add(i + 8);
                        probar = 0d;
                        int NextSpace = ran.Next(Space.Mini,Space.Max+1), NextReturn = ran.Next(Return.Mini, Return.Max+1),NextSentence = ran.Next(Sentence.Mini, Sentence.Max+1);
                        for (int i = 0; i < numericUpDown1.Value; i++)
                        {
                            Thread.Sleep(10);
                            if (ints.Count == 0) break;
                            richTextBox1.Text += GenerateChars(ints[new Random().Next(0, ints.Count)]);
                            probar += 100 / (double)numericUpDown1.Value;
                            UpdateProbar(probar);
                            if (Space.Enabled && NextSpace == 0)
                            {
                                NextSpace = ran.Next(Space.Mini, Space.Max) + 1;
                                richTextBox1.Text += " ";
                            }
                            if (Return.Enabled && NextReturn == 0) 
                            {
                                NextReturn = ran.Next(Return.Mini, Return.Max) + 1;
                                richTextBox1.Text += "\n";
                            }
                            if (NextSentence == 0)
                            {
                                NextSentence = ran.Next(Sentence.Mini, Sentence.Max) + 1;
                                if (AddPeriod)richTextBox1.Text += ". ";
                            }
                            NextReturn--;
                            NextSpace--;
                            NextSentence--;
                        }
                        //if (CapsAtFront)if (!string.IsNullOrEmpty(richTextBox1.Text))richTextBox1.Text = richTextBox1.Text[0].ToString().ToUpper() + richTextBox1.Text.TrimStart(richTextBox1.Text[0]);
                    }
                    else
                    {
                        probar = 0d;
                        for (int i2 = 0; i2 < numericUpDown1.Value; i2++)
                        {
                            UpdateProbar(probar);
                            richTextBox1.Text += deUnicode(GetRandomHexNumberEx(0x0000,0xFFFFF));
                            probar += 100 / (double)numericUpDown1.Value;
                            Thread.Sleep(1);
                        }
                    }
                    if (checkBox1.Checked)
                    {
                        string str = System.Text.RegularExpressions.Regex.Replace(richTextBox1.Text, @"(?<=\b(.{" + numericUpDown2.Value + "})+)", "$0,");
                        string[] strs = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        richTextBox1.Text = String.Join("\n", strs);
                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    if (checkBox12.Checked) richTextBox1.Text += "[";
                    probar = 0d;
                    foreach (char c in richTextBox2.Text)
                    {
                        try { richTextBox1.Text += words[c][ran.Next(words[c].Length)]; }
                        catch (KeyNotFoundException) { richTextBox1.Text += c; }
                        probar += (double)100 / richTextBox2.Text.Length;
                        UpdateProbar(probar);
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
                else if (tabControl1.SelectedIndex == 2)
                {
                    probar = 0;
                    richTextBox3.Text = richTextBox3.Text.ToUpper();
                    string[] spl = richTextBox3.Text.Split(',');
                    foreach (string s in spl)
                    {
                        probar += (double)100 / spl.Length;
                        UpdateProbar(probar);
                        richTextBox1.Text += deUnicode(s);
                    }
                }
                info("完成!");
            }
            catch (ThreadAbortException)
            {
                TaskbarManager1.SetProgressState(TaskbarProgressBarState.Error);
                if (!IsClosed)info("线程错误: 进程被用户终止,",true, true);
            }
            catch (Exception ex)
            {
                TaskbarManager1.SetProgressState(TaskbarProgressBarState.Error);
                info("线程错误: " + ex.Message + ",", true, true);
            }
            finally
            {
                TaskbarManager1.SetProgressState(TaskbarProgressBarState.NoProgress);
                取消生成CToolStripMenuItem.Enabled = 取消生成ToolStripMenuItem.Enabled = toolStripProgressBar1.Visible = toolStripStatusLabel2.Visible = button6.Enabled = false;
                开始SToolStripMenuItem.Enabled = 开始生成ToolStripMenuItem.Enabled = tabControl1.Enabled = checkBox1.Enabled = numericUpDown2.Enabled = numericUpDown1.Enabled = button1.Enabled = true;
                probar = progressBar1.Value = 100;
                toolStripStatusLabel1.Text += " 线程运行耗时" + (DateTime.Now - StartTime).TotalMilliseconds + "ms";
            }
        }

        private void UpdateProbar(double value)
        {
            progressBar1.Value = (int)value;
            TaskbarManager1.SetProgressValue((int)probar, 100);
            toolStripProgressBar1.Value = (int)value;
            toolStripStatusLabel2.Text = (int)value + "%";
            double remaining = (100 - value) * ((DateTime.Now - StartTime).TotalMilliseconds / value) / 1000;
            if (remaining < 60) info("运行中, 剩余时间: " + Math.Floor(remaining) + "\"");
            else if (remaining < 360) info("运行中, 剩余时间: " + Math.Floor(remaining / 60) + "'" + Math.Floor(remaining % 60) + "\"");
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                保存输出为文件ToolStripMenuItem_Click(sender, e);
            }
            else
            {
                保存输出为文件追加ToolStripMenuItem_Click(sender, e);
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

        /// <summary>
        /// 开始键按动
        /// </summary>
        public void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(Main));
            thread.Start();
        }

        /// <summary>
        /// 获取随机箭头符
        /// </summary>
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

        /// <summary>
        /// 获取随机十六进制
        /// <para><paramref name="digits"/>: 生成的随机数的位数</para>
        /// </summary>
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

        /// <summary>
        /// 选择生成什么字符
        /// </summary>
        private string GenerateChars(int id)
        {
            switch (id)
            {
                case 0: return characters[ran.Next(characters.Length)].ToString();
                case 1: return characters[ran.Next(characters.Length)].ToString().ToLower();
                case 2: return ran.Next(0, 10).ToString();
                case 3: return GetRandomChinese(1);
                case 4: return deUnicode(GetRandomHexNumberEx(0x0400, 0x052F));
                case 5: return deUnicode(GetRandomHexNumberEx(0x10000, 0x1FFFF, 5));
                case 6: return "";/*if (checkBox9.Checked) return deUnicode("20" + );*/
                case 7: return deUnicode(GetRandomHexNumberEx(0x3040, 0x30FF));
                case 8: return "";
                case 9: return deUnicode(GetRandomHexNumberEx(0x2800, 0x28FF));
                case 10: return GetRandomMathematicalOperator();
                case 11: return "";
                case 12: return "";
                case 13: return "";
                case 14: return "";
                case 15: return deUnicode(GetRandomHexNumberEx(0x3100, 0x312F));
                case 16: return deUnicode(GetRandomHexNumberEx(0x2300, 0x23FF));
                case 17: return GetRandomArrows();
                case 18: return deUnicode(GetRandomHexNumberEx(0x25A0, 0x25FF));
                case 19: return deUnicode(GetRandomHexNumberEx(0x2500, 0x257F));
                case 20: return deUnicode(GetRandomHexNumberEx(0x2580, 0x259F));
                case 21: return "";
                case 22: return "";
                case 23: return ran.Next(0, 2).ToString();
                case 24: return deUnicode(GetRandomHexNumberEx(0x2440, 0x245F));
                case 25: return deUnicode(GetRandomHexNumberEx(0x2460, 0x24FF));
                default: throw new ArgumentException("找不到生成选项:“" + id + "”");
            }
        }

        /// <summary>
        /// 将十六进制用Unicode转码为字符串
        /// </summary>
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
                info("复制错误: " + ex.Message, true, true);
            }

            info("复制成功!", false, false, false, 2000);
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

        /// <summary>
        /// 获取随机中文
        /// <para><paramref name="strlength"/>: 长度</para>
        /// </summary>
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

        /// <summary>
        /// 生成区码位
        /// </summary>
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
            if (!button1.Enabled && MessageBox.Show("检测到正在运行的工作, 是否关闭?", "警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            IsClosed = true;
            if (button6.Enabled)button6_Click(sender, e);
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
            if (Environment.OSVersion.Version.Major < 6) return;
            thread = new Thread(() => { });
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel2.Visible = false;
            IsClosed = false; probar = 0; 
            new Task(() =>
            {
                while (!IsClosed)
                {
                    progress = progressBar1.Value;
                    Thread.Sleep(10);
                }
            }).Start();
        }

        /// <summary>
        /// “更多”按钮被按下
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(bools,Space,Return,radioButton2.Checked,CapsAtFront,AddPeriod,AddfullPeriod,Sentence);
            form3.ShowDialog();
            Space = form3.Space;
            Return = form3.Return;
            AddfullPeriod = form3.AddfullPeriod;
            CapsAtFront = form3.CapsAtFront;
            AddPeriod = form3.AddPeriod;
            Space = form3.WordsInSentence;
            for (int i = 0; i < bools.Length; i++) bools[i] = form3.bools[i];
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        /// <summary>
        /// 取消按钮被按下
        /// </summary>
        public void button6_Click(object sender, EventArgs e)
        {
            取消生成ToolStripMenuItem.Enabled = button6.Enabled = false;
            取消生成ToolStripMenuItem.Text = button6.Text = "取消中...";
            info("正在取消");
            thread.Abort();
            thread.Join();
            取消生成ToolStripMenuItem.Text = button6.Text = "取消";
        }

        /// <summary>
        /// 获取随机十六进制Ex版
        /// <para><paramref name="minValue"/>: 随机生成的数的最小值</para>
        /// <para><paramref name="maxValue"/>: 随机生成的数的最大值</para>
        /// <para><paramref name="length"/>: 随机生成的数的长度（不足补零）</para>
        /// </summary>
        public string GetRandomHexNumberEx(int minValue,int maxValue, int length = 4)
        {
            return Convert.ToString(new Random().Next(int.Parse(Convert.ToString(minValue, 10)), int.Parse(Convert.ToString(maxValue, 10))), 16).PadLeft(length, '0');
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripStatusLabel2.Visible) Clipboard.SetDataObject(toolStripStatusLabel1.Text + ", " + toolStripStatusLabel2.Text);
                else Clipboard.SetDataObject(toolStripStatusLabel1.Text);
            }
            catch (Exception ex)
            {
                info("复制错误: " + ex.Message,true, true, false, 2000);
            }
            info("复制成功!", false, false, false, 2000);
        }

        /// <summary>
        /// 更改toolStringStatusLabel上的字或弹出提示窗
        /// <para><paramref name="Text"/>: toolStringStatusLabel.Text的新值</para>
        /// <para><paramref name="Persistence"/>: 是否保持显示</para>
        /// <para><paramref name="PersistenceMS"/>: 如果!<paramref name="Persistence"/>, 那么Text在toolStringStatusLabel上显示的时长(ms)</para>
        /// <para><paramref name="error"/>: Text在toolStringStatusLabel上是否显示为红色, 提示框上是否显示为错误</para>
        /// <para><paramref name="Messagebox"/>: 是否弹出提示窗</para>
        /// </summary>
        private void info(string Text, bool Messagebox = false, bool error = false, bool Persistence = true, int PersistenceMS = 3000)
        {
            toolStringStatusInfo(Text, Persistence, PersistenceMS, error);
            if (error)
            {
                if (Messagebox) new Thread(() => MessageBox.Show(Text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)).Start();
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                if (Messagebox) new Thread(() => MessageBox.Show(Text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)).Start();
                toolStripStatusLabel1.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 更改toolStringStatusLabel上的字
        /// <para><paramref name="Text"/>: toolStringStatusLabel.Text的新值</para>
        /// <para><paramref name="Persistence"/>: 是否保持显示</para>
        /// <para><paramref name="PersistenceMS"/>: 如果!<paramref name="Persistence"/>, 那么Text在toolStringStatusLabel上显示的时长(ms)</para>
        /// <para><paramref name="error"/>: Text在toolStringStatusLabel上是否显示为红色</para>
        /// </summary>
        private void toolStringStatusInfo(string Text, bool Persistence = true, int PersistenceMS = 3000, bool error = false)
        {
            Color color = toolStripStatusLabel1.ForeColor;
            if (error)toolStripStatusLabel1.ForeColor = Color.Red;
            else toolStripStatusLabel1.ForeColor = Color.Black;
            if (Persistence)
            {
                toolStripStatusLabel1.Text = Text;
            }
            else
            {
                new Thread(() =>
                {
                    string tmp = toolStripStatusLabel1.Text;
                    toolStripStatusLabel1.Text = Text;
                    Thread.Sleep(PersistenceMS);
                    if (toolStripStatusLabel1.Text == Text) { toolStripStatusLabel1.Text = tmp; toolStripStatusLabel1.ForeColor = color; }
                }).Start();
            }
        }

        /// <summary>
        /// 将toolStripStatusLabel1重设回“就绪”状态
        /// <para><paramref name="Time"/>: 过多久显示就绪</para>
        /// </summary>
        private void cleanInfo(int Time = 3000)
        {
            new Thread(() =>
            {
                string tmp = toolStripStatusLabel1.Text;
                Thread.Sleep(Time);
                if (toolStripStatusLabel1.Text == tmp) toolStringStatusInfo("就绪");
            }).Start();
        }

        private void 复制输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void 保存输出为文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
                    info("成功保存为文件“" + saveFileDialog1.FileName + "”");
                }
            }
            catch (Exception ex)
            {
                info("保存错误: " + ex.Message, true, true);
            }
        }

        private void 保存输出为文件追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = File.AppendText(openFileDialog1.FileName);
                    sw.WriteLine(richTextBox1.Text.Trim());
                    sw.Close();
                    info("成功保存为文件“" + openFileDialog1.FileName + "”");
                }
            }
            catch (Exception ex)
            {
                info("保存错误: " + ex.Message, true, true);
            }
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 强制退出不推荐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否强制退出, 可能会造成错误","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.OK)Environment.Exit(0);
        }

        private void 更多输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void 置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            置顶ToolStripMenuItem.Checked = !置顶ToolStripMenuItem.Checked;
        }

        private void richTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar >= 'A' && e.KeyChar <= 'F') return;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'f') return;
            if (e.KeyChar == ',') return;
            e.Handled = true;
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            progressBar1.Value = 0;
        }

        private void 重新生成窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!button1.Enabled && MessageBox.Show("检测到正在运行的工作, 是否关闭?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel) return;
            IsClosed = true;
            if (button6.Enabled)button6_Click(sender, e);
            Controls.Clear();
            InitializeComponent();
            Form1_Load(sender, e);
            IsClosed = false;
        }

        private string GetRandomMathematicalOperator()
        {
            switch (ran.Next(0, 3))
            {
                case 0:
                    return deUnicode(GetRandomHexNumberEx(0x2200, 0x22FF));
                case 1:
                    return deUnicode(GetRandomHexNumberEx(0x27C0, 0x27EF));
                case 2:
                    return deUnicode(GetRandomHexNumberEx(0x2980, 0x29FF));
                case 3:
                    return deUnicode(GetRandomHexNumberEx(0x2A00, 0x2AFF));
            }
            return "";
        }

        private void toolStripTextBox1_Paint(object sender, PaintEventArgs e)
        {
            toolStripTextBox1.Text = GetRandomHexNumberEx(0x0000, 0xFFFF).ToUpper();
        }

        private void 最小化到托盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            Hide();
        }

        private void 显示主窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible ^= true;
            Show();
        }

        private void toolStripStatusLabel1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripStatusLabel2.Visible) notifyIcon1.Text = "胡言乱语生成器\n" + toolStripStatusLabel1.Text + "\n" + toolStripStatusLabel2.Text;
            else notifyIcon1.Text = "胡言乱语生成器\n" + toolStripStatusLabel1.Text;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            notifyIcon1.Visible ^= true;
            Show();
        }
        static public int progress = 0;

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            /*ThumbnailToolBarButton Cancelbutton = new ThumbnailToolBarButton(Properties.Resources.cancelIcon, "取消");
            Cancelbutton.Click += Cancelbutton_Click;
            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(Handle, Cancelbutton);
            TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(Handle, new Rectangle(richTextBox1.Location.X, richTextBox1.Location.Y, richTextBox1.Size.Width, richTextBox1.Size.Height));*/
        }

        /*private void Cancelbutton_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            e.ThumbnailButton.Enabled = false;
        }*/
    }
}