using ExamRemind;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExamRemind
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //数据库配置文件在SqlHelper里
            string sql = "select p.xtzymc,e.xtjzrq,u.xtksxm from examination e,users u,professional p where u.xtksxm=@xtksxm and u.dqkqdm=e.xtkqdm and u.kszydm=p.xtzydm";
            SqlParameter[] prams = new SqlParameter[1];
            prams[0] = new SqlParameter("@xtksxm", "李俊强");

            //获取考试信息数据集
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataSet(CommandType.Text, sql, prams);

            DateTime examDate = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[1]);  //当前考期
            DateTime now = DateTime.Now;                                                //今天
            int count = Convert.ToInt32((examDate - now).TotalDays) - 1;                //距考期天数
            string professional = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]);  //专业

            labelControl2.Text = examDate.ToShortDateString();
            labelControl5.Text = Convert.ToString(count);
            labelControl8.Text = professional;


            string sql1 = "select s.xtkmdm,s.xtkmmc,s1.xtkmdf from subjects s,score s1,examination e,users u,professional p where s.xtkmdm=s1.xtkmdm and s1.xtkqdm=e.xtkqdm and CONVERT(date,GETDATE()) between e.xtqsrq and e.xtjzrq and u.xtksxm=@xtksxm and u.kszydm=p.xtzydm";
            SqlParameter[] prams1 = new SqlParameter[1];
            prams1[0] = new SqlParameter("@xtksxm", "李俊强");
            //获取科目信息数据集
            DataSet ds1 = new DataSet();
            ds1 = SqlHelper.ExecuteDataSet(CommandType.Text, sql1, prams1);
            gridControl1.DataMember = "Table";
            gridControl1.DataSource = ds1.Tables[0];


            string sql2 = "select s.xtkmmc,s.xtkkdd,s.xtkksj from subjects s,users u where s.dqkqbz='Y' and u.xtksxm = @xtksxm";
            SqlParameter[] prams2 = new SqlParameter[1];
            prams2[0] = new SqlParameter("@xtksxm", "李俊强");
            DataSet ds2 = new DataSet();
            ds2 = SqlHelper.ExecuteDataSet(CommandType.Text, sql2, prams2);
            gridControl2.DataMember = "Table";
            gridControl2.DataSource = ds2.Tables[0];

            //自适应列宽
            this.gridView1.BestFitColumns();
            this.gridView2.BestFitColumns();

            foreach (DataRow mDr in ds2.Tables[0].Rows)
            {
                foreach (DataColumn mDc in ds2.Tables[0].Columns)
                {
                    Console.WriteLine(mDr[mDc].ToString());
                }
            }
        }
    }
}
