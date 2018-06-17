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
    public partial class FormS2 : Form
    {
        public Form9 fm;
        public FormS2()
        {
            InitializeComponent();
        }
        public FormS2(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
            //初始化Combox1,2;

            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数

            SqlCommand MyCommand = new SqlCommand("select Dnum from D;", conn); //定义一个数据库操作指令


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

           MyCommand = new SqlCommand("select CLnum from CL;", conn); //定义一个数据库操作指令


            SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            MyDataSet = new DataSet();//定义一个数据集
            //conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter.Fill(MyDataSet);//填充数据集

            table = MyDataSet.Tables[0]; //查询第一张表



            for (int i = 0; i < table.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {

                DataRow row = table.Rows[i];    //遍历每一行,得到每一行的内容
                this.comboBox2.Items.Add(row[0].ToString());
            }

            conn.Close();//关闭数据库

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""|| textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
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
                cmd.CommandText = "insert into S values(@Snum,@Sname,@Ssex,@Sphone,@Sage,@Dnum,@CLnum)";
                cmd.Parameters.AddWithValue("@Snum", textBox1.Text);
                cmd.Parameters.AddWithValue("@Sname", textBox2.Text);
                cmd.Parameters.AddWithValue("@Ssex", textBox3.Text);
                cmd.Parameters.AddWithValue("@Sphone", textBox4.Text);
                cmd.Parameters.AddWithValue("@Sage", textBox5.Text);
                cmd.Parameters.AddWithValue("@Dnum", comboBox1.Text);
                cmd.Parameters.AddWithValue("@CLnum", comboBox2.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功！");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("添加失败！请输入正确的学号，专业号，班级号！");
                    //根据ex.Number的值给出友好的错误信息
                }

                conn.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
