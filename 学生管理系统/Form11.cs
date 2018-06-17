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
    public partial class Form11 : Form
    {
        public Form9 fm;
        public Form11()
        {
            InitializeComponent();
        }
        public Form11(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ID不得为空！");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                //定义数据库连接参数


                SqlCommand MyCommand = new SqlCommand("SELECT AdmPW FROM A where AdmID=@ID;", conn); //定义一个数据库操作指令

                MyCommand.Parameters.AddWithValue("@ID", textBox1.Text);


                SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
                SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
                DataSet MyDataSet = new DataSet();//定义一个数据集
                conn.Open();//打开数据库连接
                SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令


                SelectAdapter.Fill(MyDataSet);//填充数据集

                DataTable table = MyDataSet.Tables[0]; //查询第一张表

                if (table.Rows.Count >= 1)
                {
                    DataRow row = table.Rows[0];
                    label4.Text = row[0].ToString();
                }
                else
                {
                    MessageBox.Show("无此ID");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ID不得为空！");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                //定义数据库连接参数


                SqlCommand MyCommand = new SqlCommand("SELECT UserPW FROM U where UserID=@ID;", conn); //定义一个数据库操作指令

                MyCommand.Parameters.AddWithValue("@ID", textBox1.Text);


                SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
                SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
                DataSet MyDataSet = new DataSet();//定义一个数据集
                conn.Open();//打开数据库连接
                SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令


                SelectAdapter.Fill(MyDataSet);//填充数据集

                DataTable table = MyDataSet.Tables[0]; //查询第一张表

                if (table.Rows.Count >= 1)
                {
                    DataRow row = table.Rows[0];
                    label4.Text = row[0].ToString();
                }
                else
                {
                    MessageBox.Show("无此ID");
                }

            }
        }
    }
}
