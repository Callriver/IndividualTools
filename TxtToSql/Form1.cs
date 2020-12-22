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
        /// <summary>
        /// TXT转SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string[] tmp = memoEdit1.Text.Split("\n".ToCharArray());
            string[] s = new string[tmp.Length];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = tmp[i].Trim();
            }
            //校验空数据空字符
            if (s[0]!="")
	        {
                //空行处理
                if (s[s.Length - 1] == "")
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
                string result = tmpResult.ToString();
                result = result.Remove(result.LastIndexOf(","), 1);
                result = result.Insert(result.Length - 1, ");");
                //显示结果
                if (memoEdit1.Text == "" || memoEdit1.Text == null)
                {
                    result = "";
                }
                memoEdit2.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("输入不能为空！","温馨提示");
            }
        }
        /// <summary>
        /// TXT转SQL导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\Administrator\Desktop";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "TXT文本文件(*.txt)|*.txt|Excel(2003)文件(*.xls)|*.xls|Excel(2007)文件(*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName, Encoding.Default);
                string tmp = sr.ReadToEnd();
                sr.Close();
                memoEdit1.Text = tmp;
            }
        }
        /// <summary>
        /// SQL转字符串拼接SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string[] tmp = memoEdit3.Text.Split("\n".ToCharArray());
            string[] s = new string[tmp.Length];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = tmp[i].Trim();
            }
            //校验空数据空字符
            if (s[0] != "")
            {
                //空行处理
                if (s[s.Length - 1] == "")
                {
                    Array.Resize(ref s, s.Length - 1);
                }
                //创建结果字符串
                StringBuilder tmpResult = new StringBuilder();
                //遍历数组数据
                foreach (var item in s)
                {
                    tmpResult.AppendLine();
                    tmpResult.Append("LS_SQL := LS_SQL || '  ' || TRIM('  ");
                    //如果不是参数
                    if (item.Contains("AS_"))
                    {
                        //取到参数起始位置
                        int index1 = item.IndexOf("AS_");
                        //拼接从参数前SQL
                        tmpResult.Append(item.Substring(0, index1));
                        tmpResult.Append(" ''' || ");

                        //取到参数结束位置
                        int index2 = item.IndexOf(" ", index1);
                        //优化：如果取不到参数尾，则取当期行尾
                        if (index2 == -1)
                        {
                            index2 = item.Length;
                        }
                        //拼接从参数起始位到结束位的SQL
                        tmpResult.Append(item.Substring(index1, index2 - index1));
                        tmpResult.Append(" || ''' ");


                        //拼接参数后SQL
                        tmpResult.Append(item.Substring(index2));
                        tmpResult.Append("  ');");

                    }
                    else if (item.Contains("LS_"))
                    {
                        //取到参数起始位置
                        int index1 = item.IndexOf("LS_");
                        //拼接从参数前SQL
                        tmpResult.Append(item.Substring(0, index1));
                        tmpResult.Append(" ''' || ");

                        //取到参数结束位置
                        int index2 = item.IndexOf(" ", index1);
                        //优化：如果取不到参数尾，则取当期行尾
                        if (index2==-1)
                        {
                            index2 = item.Length;
                        }
                        //拼接从参数起始位到结束位的SQL
                        tmpResult.Append(item.Substring(index1, index2 - index1));
                        tmpResult.Append(" || ''' ");


                        //拼接参数后SQL
                        tmpResult.Append(item.Substring(index2));
                        tmpResult.Append("  ');");

                    }
                    else
                    {
                        tmpResult.Append(item);
                        tmpResult.Append("  ');");
                    }
                }
                string result = tmpResult.ToString();
                memoEdit4.Text = result;
            }
            else
            {
                MessageBox.Show("输入不能为空！", "温馨提示");
            }
        }
    }
}
