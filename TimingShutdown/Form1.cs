using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimingShutdown
{
    public partial class Form1 : Form
    {
        int temp = 0;//秒数
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            label3.Visible = false;
            label3.Text = "系统将会在 "+temp+" 秒后自动关闭";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double time = Util.txtConvertToInt(textBox1.Text)*60;
            temp = (int)time;
            if (textBox1.Text == "")
            {
                MessageBox.Show("输入不能为空！");
            }
            else
            {
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                //启动程序
                p.Start();
                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine("shutdown.exe -s -t {0}", time);
                this.timer1.Enabled = true;
                //设置时间间隔（毫秒为单位）
                this.timer1.Interval = 1000;
                timer1.Start();
                button2.Enabled = true;
                label3.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();//向cmd窗口发送输入信息
            p.StandardInput.WriteLine("shutdown  /a  &exit");
            MessageBox.Show("计划中的关机已取消");
            button2.Enabled = false;
            this.timer1.Stop();
            this.timer1.Enabled = false;
            this.timer1.Dispose();
            temp = 0;
            label3.Text = "系统将会在"+temp+"秒后自动关闭";
            label3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();//向cmd窗口发送输入信息
            p.StandardInput.WriteLine("shutdown  /r  &exit");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            temp -= 1;
            label3.Text = "系统将会在 " + temp + " 秒后自动关闭";
        }
    }
}
