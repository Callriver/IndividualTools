using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TxtToSql
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string[] tmp = memoEdit1.Text.Split("\n".ToCharArray());
            string[] s=new string[tmp.Length];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = tmp[i].Trim();
            }
            //空行处理
            if (s[s.Length-1]=="")
            {
                Array.Resize(ref s, s.Length - 1);
            }

            StringBuilder tmpResult = new StringBuilder("select * from x where x.x in (");
            tmpResult.AppendLine();
            foreach (var item in s)
            {
                tmpResult.Append("'" + item + "',");
                tmpResult.AppendLine();
            }
            string result =tmpResult.ToString();
            result = result.Remove(result.LastIndexOf(","),1);
            result = result.Insert(result.Length - 1, ");");
            //显示结果
            if (memoEdit1.Text==""||memoEdit1.Text==null)
            {
                result = "";
            }
            memoEdit2.Text = result.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\Administrator\Desktop";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "TXT文本文件(*.txt)|*.txt|Excel(2003)文件(*.xls)|*.xls|Excel(2007)文件(*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName, Encoding.Default);
                string tmp = sr.ReadToEnd();
                sr.Close();
                memoEdit1.Text = tmp;
            }
        }
    }
}
