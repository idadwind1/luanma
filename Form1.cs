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
        #region arrs
        string[] arra = { "ä", "ā", "á", "ǎ", "à", "ă", "å", "ǻ", "ǟ", "ǡ", "ǻ", "ȁ", "ȃ", "ȧ", "ᶏ", "ḁ", "ẚ", "ạ", "ả", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ắ", "ằ", "ẳ", "ẵ", "ặ", "ɑ", "α", "ά", "ὰ", "ἀ", "ἁ", "ἂ", "ἃ", "ἆ", "ἇ", "ᾂ", "ᾃ", "ᾰ", "ᾱ", "ᾲ", "ᾳ", "ᾴ", "ᾶ", "ᾷ", "ⱥ", "𐓘", "𐓙", "𐓚" };
        string[] arraa = { "Ā", "Á", "Ǎ", "À", "Â", "Ã", "Ä", "Å", "Ǻ", "Ά", "Ă", "Δ", "Λ", "Д", "Ą" };
        string[] arrb = { "b", "ь", "в", "Ъ", "Б", "б", "β", "ƀ", "ƃ", "ɓ", "ᵬ", "ᶀ", "ḃ", "ḅ", "ḇ", "ꞗ" };
        string[] arrbb = { "ß", "฿" };
        string[] arrc = { "c", "ç", "ς", "ĉ", "č", "ċ", "ć", "ĉ", "ċ", "ƈ", "ȼ", "¢", "ɕ", "ḉ", "ꞓ", "ꞔ" };
        string[] arrcc = { "Č", "Ç", "Ĉ", "Ć", "€" };
        string[] arrd = { "d", "ď", "đ", "₫", "ð", "δ" };
        string[] arrdd = { "Ď", "Ð" };
        string[] arre = { "e", "ē", "é", "ě", "è", "ê", "ĕ", "ė", "ë", "ę", "з", "ε", "έ", "э", "℮" };
        string[] arree = { "E", "Ē", "É", "Ě", "È", "Ĕ", "Ё", "Σ", "Έ", "Є", "Э", "З" };
        string[] arrf = { "f", "ƒ" };
        string[] arrff = { "F", "₣" };
        string[] arrg = { "ḡ", "ģ", "ǧ", "ĝ", "ğ", "ġ", "ǥ", "ǵ", "ɠ", "ᶃ", "ꞡ" };
        string[] arrgg = { "Ḡ", "Ǵ", "Ǧ", "Ĝ", "Ğ", "Ģ", "Ġ", "Ɠ", "Ǥ", "Ꞡ" };
        string[] arrh = { "ĥ", "ħ", "ђ", "н" };
        string[] arrhh = { "H", "Ĥ", "Ħ" };
        string[] arri = { "ı", "ī", "í", "ǐ", "ì", "ĭ", "î", "ï", "ί", "į", "ΐ" };
        string[] arrii = { "Ī", "Í", "Ǐ", "Ì", "Î", "Ï", "Ĭ", "Ί" };
        string[] arrj = { "j" };
        string[] arrjj = { "J", "Ĵ" };
        string[] arrk = { "ƙ", "κ" };
        string[] arrkk = { "К" };
        string[] arrl = { "ŀ", "ļ", "ℓ", "ĺ", "ļ", "ľ", "ł", "ι" };
        string[] arrll = { "Ŀ", "£", "Ļ", "Ł", "Ĺ" };
        string[] arrm = { "m", "₥", "м" };
        string[] arrmm = { "M" };
        string[] arrn = { "ń", "ň", "ŉ", "η", "ή", "и", "й", "ñ", "л", "п", "π" };
        string[] arrnn = { "Ń", "Ň", "И", "Й", "Π", "Л" };
        string[] arro = { "ō", "ó", "ŏ", "ò", "ô", "õ", "ö", "ő", "σ", "ø", "ǿ" };
        string[] arroo = { "Ō", "Ó", "Ǒ", "Ò", "Ô", "Õ", "Ö", "Ό", "Θ", "Ǿ" };
        string[] arrp = { "p", "ρ", "ƥ", "φ" };
        string[] arrpp = { "P", "Þ", "₽" };
        string[] arrq = { "q", "ʠ", "ɋ" };
        string[] arrqq = { "Q", "Ɋ" };
        string[] arrr = { "ř", "ŗ", "г", "ѓ", "ґ", "я" };
        string[] arrrr = { "Ř", "Я", "Г", "Ґ" };
        string[] arrs = { "ś", "š", "ŝ", "ș", "ş", "ƨ" };
        string[] arrss = { "Š", "Ş", "Ș", "§" };
        string[] arrt = { "ț", "ţ", "ť", "ŧ", "т", "τ" };
        string[] arrtt = { "Ť", "Ţ", "Ț", "Ŧ" };
        string[] arru = { "ū", "ú", "ǔ", "ù", "û", "ũ", "ů", "ų", "ü", "ǖ", "ǘ", "ǚ", "ǜ", "ύ", "ϋ", "ΰ", "µ", "ц", "џ" };
        string[] arruu = { "Ū", "Ǔ", "Ǖ", "Ǘ", "Ǚ", "Ǜ", "Ц" };
        string[] arrv = { "ν" };
        string[] arrvv = { "V", "V", "Ṽ", "Ṿ", "Ꝟ" };
        string[] arrw = { "ẃ", "ẁ", "ẅ", "ŵ", "ш", "щ", "ω", "ώ" };
        string[] arrww = { "Ẁ", "Ẃ", "Ẅ", "Ŵ", "Ш", "Щ" };
        string[] arrx = { "x", "ж" };
        string[] arrxx = { "X", "Ж" };
        string[] arry = { "y", "ỳ", "ŷ", "ч", "γ" };
        string[] arryy = { "Ϋ", "Ÿ", "Ŷ", "Ỳ", "Ύ", "Ψ", "￥", "У", "Ў", "Ч" };
        string[] arrz = { "z", "ź", "ż", "ž", "ƶ", "ȥ", "ʐ", "ᵶ", "ᶎ", "ẑ", "ẓ", "ẕ", "ⱬ" };
        string[] arrzz = { "Z", "Ź", "Ż", "Ž", "Ƶ", "Ȥ", "Ẓ", "Ẕ", "Ẑ", "Ⱬ" };
        #endregion

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
                        #region if
                        if (c == 'A')
                        {
                            richTextBox1.Text += arraa[ran.Next(0, arraa.Length)];
                        }
                        else if (c == 'B')
                        {
                            richTextBox1.Text += arrbb[ran.Next(0, arrbb.Length)];
                        }
                        else if (c == 'C')
                        {
                            richTextBox1.Text += arrcc[ran.Next(0, arrcc.Length)];
                        }
                        else if (c == 'D')
                        {
                            richTextBox1.Text += arrdd[ran.Next(0, arrdd.Length)];
                        }
                        else if (c == 'E')
                        {
                            richTextBox1.Text += arree[ran.Next(0, arree.Length)];
                        }
                        else if (c == 'F')
                        {
                            richTextBox1.Text += arrff[ran.Next(0, arra.Length)];
                        }
                        else if (c == 'G')
                        {
                            richTextBox1.Text += arrgg[ran.Next(0, arrgg.Length)];
                        }
                        else if (c == 'H')
                        {
                            richTextBox1.Text += arrhh[ran.Next(0, arrhh.Length)];
                        }
                        else if (c == 'I')
                        {
                            richTextBox1.Text += arrii[ran.Next(0, arrii.Length)];
                        }
                        else if (c == 'J')
                        {
                            richTextBox1.Text += arrjj[ran.Next(0, arrjj.Length)];
                        }
                        else if (c == 'K')
                        {
                            richTextBox1.Text += arrkk[ran.Next(0, arrkk.Length)];
                        }
                        else if (c == 'L')
                        {
                            richTextBox1.Text += arrll[ran.Next(0, arrll.Length)];
                        }
                        else if (c == 'M')
                        {
                            richTextBox1.Text += arrmm[ran.Next(0, arrmm.Length)];
                        }
                        else if (c == 'N')
                        {
                            richTextBox1.Text += arrnn[ran.Next(0, arrnn.Length)];
                        }
                        else if (c == 'O')
                        {
                            richTextBox1.Text += arroo[ran.Next(0, arroo.Length)];
                        }
                        else if (c == 'P')
                        {
                            richTextBox1.Text += arrpp[ran.Next(0, arrpp.Length)];
                        }
                        else if (c == 'Q')
                        {
                            richTextBox1.Text += arrqq[ran.Next(0, arrqq.Length)];
                        }
                        else if (c == 'R')
                        {
                            richTextBox1.Text += arrrr[ran.Next(0, arrrr.Length)];
                        }
                        else if (c == 'S')
                        {
                            richTextBox1.Text += arrss[ran.Next(0, arrss.Length)];
                        }
                        else if (c == 'T')
                        {
                            richTextBox1.Text += arrtt[ran.Next(0, arrtt.Length)];
                        }
                        else if (c == 'U')
                        {
                            richTextBox1.Text += arruu[ran.Next(0, arruu.Length)];
                        }
                        else if (c == 'V')
                        {
                            richTextBox1.Text += arrvv[ran.Next(0, arrvv.Length)];
                        }
                        else if (c == 'W')
                        {
                            richTextBox1.Text += arrww[ran.Next(0, arrww.Length)];
                        }
                        else if (c == 'X')
                        {
                            richTextBox1.Text += arrxx[ran.Next(0, arrxx.Length)];
                        }
                        else if (c == 'Y')
                        {
                            richTextBox1.Text += arryy[ran.Next(0, arryy.Length)];
                        }
                        else if (c == 'Z')
                        {
                            richTextBox1.Text += arrzz[ran.Next(0, arrzz.Length)];
                        }
                        else if (c == 'a')
                        {
                            richTextBox1.Text += arra[ran.Next(0, arra.Length)];
                        }
                        else if (c == 'b')
                        {
                            richTextBox1.Text += arrb[ran.Next(0, arrb.Length)];
                        }
                        else if (c == 'c')
                        {
                            richTextBox1.Text += arrc[ran.Next(0, arrc.Length)];
                        }
                        else if (c == 'd')
                        {
                            richTextBox1.Text += arrd[ran.Next(0, arrd.Length)];
                        }
                        else if (c == 'e')
                        {
                            richTextBox1.Text += arre[ran.Next(0, arre.Length)];
                        }
                        else if (c == 'f')
                        {
                            richTextBox1.Text += arrf[ran.Next(0, arrf.Length)];
                        }
                        else if (c == 'g')
                        {
                            richTextBox1.Text += arrg[ran.Next(0, arrg.Length)];
                        }
                        else if (c == 'h')
                        {
                            richTextBox1.Text += arrh[ran.Next(0, arrh.Length)];
                        }
                        else if (c == 'i')
                        {
                            richTextBox1.Text += arri[ran.Next(0, arri.Length)];
                        }
                        else if (c == 'j')
                        {
                            richTextBox1.Text += arrj[ran.Next(0, arrj.Length)];
                        }
                        else if (c == 'k')
                        {
                            richTextBox1.Text += arrk[ran.Next(0, arrk.Length)];
                        }
                        else if (c == 'l')
                        {
                            richTextBox1.Text += arrl[ran.Next(0, arrl.Length)];
                        }
                        else if (c == 'm')
                        {
                            richTextBox1.Text += arrm[ran.Next(0, arrm.Length)];
                        }
                        else if (c == 'n')
                        {
                            richTextBox1.Text += arrn[ran.Next(0, arrn.Length)];
                        }
                        else if (c == 'o')
                        {
                            richTextBox1.Text += arro[ran.Next(0, arro.Length)];
                        }
                        else if (c == 'p')
                        {
                            richTextBox1.Text += arrp[ran.Next(0, arrp.Length)];
                        }
                        else if (c == 'q')
                        {
                            richTextBox1.Text += arrq[ran.Next(0, arrq.Length)];
                        }
                        else if (c == 'r')
                        {
                            richTextBox1.Text += arrr[ran.Next(0, arrr.Length)];
                        }
                        else if (c == 's')
                        {
                            richTextBox1.Text += arrs[ran.Next(0, arrs.Length)];
                        }
                        else if (c == 't')
                        {
                            richTextBox1.Text += arrt[ran.Next(0, arrt.Length)];
                        }
                        else if (c == 'u')
                        {
                            richTextBox1.Text += arru[ran.Next(0, arru.Length)];
                        }
                        else if (c == 'v')
                        {
                            richTextBox1.Text += arrv[ran.Next(0, arrv.Length)];
                        }
                        else if (c == 'w')
                        {
                            richTextBox1.Text += arrw[ran.Next(0, arrw.Length)];
                        }
                        else if (c == 'x')
                        {
                            richTextBox1.Text += arrx[ran.Next(0, arrx.Length)];
                        }
                        else if (c == 'y')
                        {
                            richTextBox1.Text += arry[ran.Next(0, arry.Length)];
                        }
                        else if (c == 'z')
                        {
                            richTextBox1.Text += arrz[ran.Next(0, arrz.Length)];
                        }
                        else
                        {
                            richTextBox1.Text += c;
                        }
                        #endregion
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
            return "";
        }

        public string GetRandomMathematicalOperator()
        {
            return "";
        }

        public string GetRandomMiscellaneousTechnical()
        {
            return deUnicode("23" + GetRandomHexNumber(2));
        }

        public string GetRandomGeometricShapes()
        {
            return "";
        }

        public string GetRandomMiscellaneousSymbols()
        {
            return "";
        }

        public string GetRandomDingbats()
        {
            return "";
        }

        public string GetRandomCoptic()
        {
            return "";
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
                case 4: richTextBox1.Text += GetRandomCyrillic();break;
                case 5: richTextBox1.Text += deUnicode("1" + GetRandomHexNumber(4));break;
                case 6: /*if (checkBox9.Checked) richTextBox1.Text += deUnicode("20" + );*/break;
                case 7: richTextBox1.Text += GetRandomJapanese(); break;
                case 8: break;
                case 9: richTextBox1.Text += deUnicode("28" + GetRandomHexNumber(2));break;
                case 10:richTextBox1.Text += GetRandomMathematicalOperator();break;
                case 11:break;
                case 12:break;
                case 13:break;
                case 14:break;
                case 15:richTextBox1.Text += deUnicode("31" + new Random().Next(0, 2) + GetRandomHexNumber(1));break;
                case 16:richTextBox1.Text += GetRandomMiscellaneousTechnical();break;
                case 17:break;
                case 18:break;
                case 19:break;
                case 20:richTextBox1.Text += "1";break;
                case 21:break;
                case 22:break;
                default:break;
            }
        }

        public string GetRandomCyrillic()
        {
            if (new Random().Next(0, 1) == 0) return deUnicode("04" + GetRandomHexNumber(2));
            else return deUnicode("05" + new Random().Next(0, 2) + GetRandomHexNumber(1));
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

        public string GetRandomBlock()
        {
            return "";
        }

        public string GetRandomJapanese()
        {
            switch (new Random().Next(0, 11))
            {
                case 0:
                    return deUnicode("304" + GetRandomHexNumber(1));
                case 1:
                    return deUnicode("305" + GetRandomHexNumber(1));
                case 2:
                    return deUnicode("306" + GetRandomHexNumber(1));
                case 3:
                    return deUnicode("307" + GetRandomHexNumber(1));
                case 4:
                    return deUnicode("308" + GetRandomHexNumber(1));
                case 5:
                    return deUnicode("309" + GetRandomHexNumber(1));
                case 6:
                    return deUnicode("30A" + GetRandomHexNumber(1));
                case 7:
                    return deUnicode("30B" + GetRandomHexNumber(1));
                case 8:
                    return deUnicode("30C" + GetRandomHexNumber(1));
                case 9:
                    return deUnicode("30D" + GetRandomHexNumber(1));
                case 10:
                    return deUnicode("30E" + GetRandomHexNumber(1));
                case 11:
                    return deUnicode("30F" + GetRandomHexNumber(1));
            }
            return "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button6.Text = "取消中...";
            thread.Abort();
            thread.Join();
            button6.Text = "取消";
        }
    }
}