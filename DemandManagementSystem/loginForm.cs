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
using DevExpress.XtraEditors;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
namespace DemandManagementSystem

{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        //连接字符串
        private string connectionString = "User Id=rxsoft;Password=rxsoft;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.93.100)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))";
        //用户名及密码
        Dictionary<string, User> users = new Dictionary<string, User>();
        public loginForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex==-1)
            {

                XtraMessageBox.AllowCustomLookAndFeel = true;
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "项目不能为空", "温馨提示");
            }
            else
            {
                saveLogininfo(checkEdit1);
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                t.ApartmentState = System.Threading.ApartmentState.STA;
                t.Start();
                this.Close();    
            }
        }
        /// <summary>
        /// 打开主窗口
        /// </summary>
        public static void ThreadProc()
        {
            Application.Run(new mainForm());//mainForm是要打开的窗口            
        }
        /// <summary>
        /// 密码框回车获取项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                getProjectInfo();
            }
        }
        /// <summary>
        /// 用户输入框回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// 保存登录信息
        /// </summary>
        private void saveLogininfo(CheckEdit checkEdit){
             string username = this.userText.Text.Trim();
            string password = this.passText.Text.Trim();

            User user = new User();
            FileStream fs = new FileStream("data.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            //  清除集合中所有键值对
            users.Clear();
            
            if (checkEdit.Checked)       //  如果单击了记住密码的功能
            {   //  在文件中保存密码
                user.Username = username;
                user.Password = password;
                users.Add(user.Username, user);
            }
            else
            {   //  不在文件中保存密码

            }

            
            //要先将User类先设为可以序列化(即在类的前面加[Serializable])
            bf.Serialize(fs, users);
            //user.Password = this.PassWord.Text;
            fs.Close();
        }

        private void getProjectInfo()
        {
            comboBoxEdit1.Properties.Items.Clear();
            if (userText.Text == "" || passText.Text == "")
            {
                XtraMessageBox.Show("用户名或密码不能为空!", "温馨提示");
            }
            else
            {
                string sql = "select * from xtm08 where userid = :userid and password = :password";
                OracleParameter[] prams = new OracleParameter[2];
                prams[0] = new OracleParameter(":userid", userText.Text);
                prams[1] = new OracleParameter(":password", passText.Text);
                string result = "";
                try
                {
                    result = OracleHelper.ExecuteScalar(connectionString, CommandType.Text, sql, prams).ToString();

                }
                catch (Exception)
                {

                    XtraMessageBox.Show("用户名或密码错误!", "温馨提示");
                    return;
                }
                string sql2 = "select xm.name from xtm08 ,xttdata xm where xtm08.userid=xm.userid and xtm08.userid=:userid";
                OracleParameter[] prams2 = new OracleParameter[1];
                prams2[0] = new OracleParameter(":userid", userText.Text);
                DataTable projects = OracleHelper.ExecuteDataTable(connectionString, CommandType.Text, sql2, prams2);
                if (projects.Rows.Count != 0)
                {
                    for (int i = 0; i < projects.Rows.Count; i++)
                    {
                        comboBoxEdit1.Properties.Items.Add(projects.Rows[i]["name"].ToString());
                    }
                    comboBoxEdit1.SelectedIndex = 0;
                    //this.simpleButton1.Focus();   ///*************不知道为什么不是获取到焦点了,而是直接登录了
                }
            }
        }

        /// <summary>
        /// 读取配置文件寻找记住的用户名和密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginForm_Load(object sender, EventArgs e)
        {
                        
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);

            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                users = bf.Deserialize(fs) as Dictionary<string, User>;
                foreach (User user in users.Values)
                {
                    this.userText.Text = user.Username;
                    this.passText.Text = user.Password;
                }
                if (users.Count<= 0)
                {
                    checkEdit1.Checked = false;
                }
                else
                {
                    checkEdit1.Checked = true;
                    fs.Close();
                    getProjectInfo();
                }
                
            }
        }
    }
}
