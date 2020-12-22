using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoYouLoveMe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我也爱你哟思密达");
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            int x = this.ClientSize.Width-button2.Width;
            int y = this.ClientSize.Height - button2.Height;
            Random r=new Random();
            button2.Location=new Point(r.Next(0,x+1),r.Next(0,y+1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你不爱我我也要爱你哟!");
        }
    }
}
