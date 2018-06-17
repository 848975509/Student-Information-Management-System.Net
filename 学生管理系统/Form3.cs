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
    public partial class Form3 : Form
    {
        public Form2 f2;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form2 tf2)
        {
            InitializeComponent();
            f2 = tf2;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("ID与密码不得为空！");
            }
            else {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                conn.Open();



                SqlCommand MyCommand = new SqlCommand("SELECT * FROM U where UserID=@ID;", conn); //定义一个数据库操作指令

                MyCommand.Parameters.AddWithValue("@ID", textBox1.Text);


                SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
                SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
                DataSet MyDataSet = new DataSet();//定义一个数据集
               
                SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令


                SelectAdapter.Fill(MyDataSet);//填充数据集

                DataTable table = MyDataSet.Tables[0]; //查询第一张表
                conn.Close();
                if (table.Rows.Count >= 1)
                {
                    MessageBox.Show("此用户已存在！");
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into U values(@UserID,@UserPW,@Uname,@Uphone,@Umail);";

                    cmd.Parameters.AddWithValue("@UserID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@UserPW", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Uname", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Uphone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Umail", textBox5.Text);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("注册成功");
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                    
                }
            }
        }
    }
}
