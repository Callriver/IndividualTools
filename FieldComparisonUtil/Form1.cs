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
            //2.进行比较,取新集合中不存在于旧集合的字段
            //3.把这些数据写到memoedit3中
        }

        /// <summary>
        /// 获取旧的字段集合
        /// </summary>
        /// <returns></returns>
        private List<string> getOldFields()
        {
            return null;
        }

        /// <summary>
        ///获取新的字段集合
        /// </summary>
        /// <returns></returns>
        private List<string> getNewFields()
        {
            return null;
        }
    }
}
