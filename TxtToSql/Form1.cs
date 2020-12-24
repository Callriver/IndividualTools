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
                    //搜索起始位置，结束位置，参数尾位置
                    int startIndex = 0;
                    int endIndex = item.Length;

                    //加拼接头
                    tmpResult.AppendLine();
                    tmpResult.Append("LS_SQL := LS_SQL || '  ' || TRIM('  ");
                    //判断是否有参数
                    if (item.Contains("AS_")||item.Contains("LS_"))
	                {
		                //多参数遍历处理
                        while (item.IndexOf("AS_", startIndex, endIndex - startIndex) != -1 || item.IndexOf("LS_", startIndex, endIndex - startIndex) != -1 || item.IndexOf("AN_", startIndex, endIndex - startIndex) != -1)
                        {

                            //参数起始位置
                            int index1 = 0;
                            //判断参数类型
                            if (item.IndexOf("AS_",startIndex,endIndex-startIndex)!=-1)
	                        {
		                        index1=item.IndexOf("AS_",startIndex,endIndex-startIndex);
	                        }else if (item.IndexOf("LS_",startIndex,endIndex-startIndex)!=-1)
	                        {
		                        index1=item.IndexOf("LS_",startIndex,endIndex-startIndex);
                            }
                            else if (item.IndexOf("AN_",startIndex,endIndex-startIndex)!=-1)
                            {
                                index1=item.IndexOf("AN_",startIndex,endIndex-startIndex);
                            }
                        
                            //拼接参数前SQL
                            tmpResult.Append(item.Substring(startIndex, index1-startIndex));
                            tmpResult.Append(" ''' || ");

                            //取到参数结束位置
                            int index2 = item.IndexOf(" ", index1, endIndex-index1);
                            //优化：如果取不到参数尾，则取当期行尾
                            if (index2 == -1)
                            {
                                index2 = item.Length;
                            }
                            //拼接从参数起始位到结束位的SQL
                            tmpResult.Append(item.Substring(index1, index2 - index1));
                            tmpResult.Append(" || ''' ");

                            //修改起始位置,参数尾位置
                            startIndex = index2;
                        }
                        //循环完毕后修改结束位置为0
                        endIndex = 0;
                        //拼接参数后SQL，最后一次循环后的起始位置即参数结尾位置
                        tmpResult.Append(item.Substring(startIndex));
                        tmpResult.Append("  ');");
                    } else
                    {
                        //如果没有参数
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
