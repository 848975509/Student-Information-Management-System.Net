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
    
    public partial class Form10 : Form
    {
        public Form9 fm;
        public Form10()
        {
            InitializeComponent();
        }
        public Form10(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""|| textBox1.Text == "")
            {
                MessageBox.Show("用户名，密码，不得为空!");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("密码不一致！");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update U set UserPW=@PW where UserID=@ID;";

                cmd.Parameters.AddWithValue("@PW", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("没有此账号");
                }
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("用户名，密码，不得为空!");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("密码不一致！");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update A set AdmPW=@PW where AdmID=@ID;";

                cmd.Parameters.AddWithValue("@PW", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("没有此账号");
                }
                conn.Close();
            }
        }
    }
}
