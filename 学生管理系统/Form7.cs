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
    public partial class Form7 : Form
    {
        public Form4 fm;
        public String ID;
        public Form7()
        {
            InitializeComponent();
        }
        public Form7(Form4 tfm,String ID)
        {
            fm = tfm;
            this.ID = ID;
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
                MessageBox.Show("密码不得为空");
            }
            else if(textBox1.Text!= textBox2.Text)
            {
                MessageBox.Show("密码不一致");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update U set UserPW=@PW where UserID=@ID;";

                cmd.Parameters.AddWithValue("@PW", textBox1.Text);
                cmd.Parameters.AddWithValue("@ID", ID);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                conn.Close();
            }    
        }
    }
}
