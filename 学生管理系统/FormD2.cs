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
    public partial class FormD2 : Form
    {
        public Form9 fm;
        public FormD2()
        {
            InitializeComponent();
        }
        public FormD2(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("输入不得为空！");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                //定义数据库连接参数

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into D values(@Dnum,@Dname)";
                cmd.Parameters.AddWithValue("@Dnum", textBox1.Text);
                cmd.Parameters.AddWithValue("@Dname", textBox2.Text);


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功！");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("添加失败！(专业号不能重复)");
                    //根据ex.Number的值给出友好的错误信息
                }

                conn.Close();
            }
        }
    }
}
