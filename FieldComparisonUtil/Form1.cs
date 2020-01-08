using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FieldComparisonUtil
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //1.获取两个集合
            List<string> olds = getOldFields();
            
            List<string> news = getNewFields();
            
            //2.进行比较,取新集合中不存在于旧集合的字段
            List<string> chajiList = news.Except(olds).ToList();
            
            //3.把这些数据写到memoedit3中
            string result = "";
            foreach (string item in chajiList)
            {
                result = result + "\r\n" + item;
            }
            memoEdit3.Text = "";
            memoEdit3.Text = result;
            memoEdit1.Text = "";
            memoEdit2.Text = "";
        }

        /// <summary>
        /// 获取旧的字段集合
        /// </summary>
        /// <returns></returns>
        private List<string> getOldFields()
        {
            List<string> olds = null;
            if (memoEdit1.Text!=null||memoEdit1.Text!="")
            { 
                olds = memoEdit1.Lines.ToList();
            }
            else
            {
                XtraMessageBox.Show("数据字典内容不能为空");
            }
            return olds;
        }

        /// <summary>
        ///获取新的字段集合
        /// </summary>
        /// <returns></returns>
        private List<string> getNewFields()
        {
            List<string> news = null;
            if (memoEdit2.Text != null || memoEdit2.Text != "")
            {
                news = memoEdit2.Lines.ToList();
            }
            else
            {
                XtraMessageBox.Show("现表内容不能为空");
            }
            return news;
        }
    }
}
