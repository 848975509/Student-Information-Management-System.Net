using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    public partial class Form8 : Form
    {
        public Form1 fm;
        public Form8()
        {
            InitializeComponent();
        }
        public Form8(Form1 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数


            SqlCommand MyCommand = new SqlCommand("SELECT AdmID,AdmPW FROM A", conn); //定义一个数据库操作指令
            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表
            StringBuilder strData = new StringBuilder();
            
            DataRow row;
            row = table.Rows[0];    //遍历每一行,得到每一行的内容
            if (row[0].ToString() == textBox1.Text && row[1].ToString() == textBox2.Text)
            {
                Form9 frm = new 学生管理系统.Form9(this);
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
            conn.Close();//关闭数据库
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }
    }
}
