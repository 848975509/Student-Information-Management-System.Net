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
    public partial class FormC3 : Form
    {
        public Form9 fm;
        public FormC3()
        {
            InitializeComponent();
        }
        public FormC3(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();

            this.comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数

            SqlCommand MyCommand = new SqlCommand("select Cnum from C;", conn); //定义一个数据库操作指令


            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表



            for (int i = 0; i < table.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {

                DataRow row = table.Rows[i];    //遍历每一行,得到每一行的内容
                this.comboBox1.Items.Add(row[0].ToString());
            }
            conn.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("输入不得为空！");
            }
            else
            {
                SqlConnection conn = new SqlConnection();//定义一个数据连接实例
                conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update C set Cname=@Cname,Cfreq=@Cfreq where Cnum=@Cnum;";

                cmd.Parameters.AddWithValue("@Cname", textBox1.Text);
                cmd.Parameters.AddWithValue("@Cfreq", textBox2.Text);
                cmd.Parameters.AddWithValue("@Cnum", comboBox1.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败！无此课程号号！");
                }
                conn.Close();
            }
        }
    }
}
