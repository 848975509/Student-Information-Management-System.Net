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
    public partial class FormCL2 : Form
    {
        public Form9 fm;
        public FormCL2()
        {
            InitializeComponent();
        }
        public FormCL2(Form9 tfm)
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
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
                cmd.CommandText = "insert into CL values(@CLnum,@CLname,@Hname)";
                cmd.Parameters.AddWithValue("@CLnum", textBox1.Text);
                cmd.Parameters.AddWithValue("@CLname", textBox2.Text);
                cmd.Parameters.AddWithValue("@Hname", textBox3.Text);
                
                try{
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功！");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("添加失败！(班级号不能重复)");
                    //根据ex.Number的值给出友好的错误信息
                }

                conn.Close();
                
            }
        }
    }
}
