using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result;
                result = ConvertUtil.HexStrToTen(textBox1.Text);
                textBox2.Text = result;
            }
            catch (Exception)
            {

                MessageBox.Show("转换异常");
            }

        }
    }
}
