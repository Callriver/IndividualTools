using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rxsoft.Util.DataBase;
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraEditors;namespace DemandManagementSystem

{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private string connectionString = "User Id=rxsoft;Password=rxsoft;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.93.100)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))";
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex==-1)
            {

                XtraMessageBox.AllowCustomLookAndFeel = true;
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "项目不能为空", "温馨提示");

            }
        }

        private void passText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (userText.Text==""||passText.Text=="")
                {
                    XtraMessageBox.Show("用户名或密码不能为空!");
                }
                else
                {
                    string sql="select * from xtm08 where userid = :userid and password = :password";
                    OracleParameter[] prams=new OracleParameter[2];
                    prams[0] = new OracleParameter(":userid", userText.Text);
                    prams[1] = new OracleParameter(":password", passText.Text);
                    string result = "";
                    try
                    {
                        result = OracleHelper.ExecuteScalar(connectionString, CommandType.Text, sql, prams).Equals(result).ToString();
                        XtraMessageBox.Show("success!");
                    }
                    catch (Exception)
                    {

                        XtraMessageBox.Show("用户名或密码错误!");
                    }
                    
                }
                
            }
        }

        private void userText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
