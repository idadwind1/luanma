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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private bool IsClosed = false;
        private void Form4_Load(object sender, EventArgs e)
        {
            progressBar1.Controls.Add(label1);
            progressBar1.Controls.Add(label2);
            progressBar1.SuspendLayout();
            new System.Threading.Thread(() =>
            {
                while (!IsClosed)
                {
                    int progress = progressBar1.Value, remaining = 100 - progress;
                    DateTime startTime = Form1.StartTime;
                    double pass = (DateTime.Now - startTime).TotalMilliseconds, speed = pass / progress,
                    speed2 = progress / pass;
                    if (!Form1.thread.IsAlive)
                    {
                        label2.Text = "";
                        progressBar1.ForeColor = Color.Black;
                        label1.Text = "进程尚未启动";
                    }
                    else
                    {
                        label2.Text = progressBar1.Value + "%";
                        progressBar1.ForeColor = Color.FromArgb(6, 176, 37); 
                        if (speed == 0 || speed.ToString() == "∞") label1.Text = "进度百分比: " + label2.Text +
                        "\r\n剩余百分比: " + remaining +
                        "%\r\n进度开始时间: " + startTime.ToString("yyyy/MM/dd hh:mm:ss.FFFFFFF") +
                        "\r\n已运行: " + pass +
                        "ms\r\n速度: " + speed +
                        "\r\n预估剩余时间: [无法计算]";
                        else label1.Text = "进度百分比: " + label2.Text +
                            "\r\n剩余百分比: " + remaining +
                            "%\r\n进度开始时间: " + startTime.ToString("yyyy/MM/dd hh:mm:ss.FFFFFFF") +
                            "\r\n已运行: " + pass +
                            "ms\r\n速度: " + speed +
                            "ms per 1%\r\n(" + (speed / 1000) +
                            "s per 1%,\r\n" + speed2 +
                            "% per ms,\r\n" + (speed2 * 1000) +
                            "% per s)\r\n预估剩余时间: " + (remaining * speed) +
                            "ms\r\n(" + (remaining * speed / 1000) +
                            "s,\r\n" + (remaining * speed / 60000) +
                            "m)";
                    }
                    label2.Location = new Point(ClientRectangle.Right - label2.Width, ClientRectangle.Bottom - label2.Height);
                    progressBar1.Value = Form1.progress;
                    System.Threading.Thread.Sleep(10);
                }
            }).Start();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClosed = true;
        }

        private void progressBar1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (Control control in progressBar1.Controls)
                {
                    control.Visible ^= true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(label1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制错误!\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
