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
    public partial class FormSC2 : Form
    {
        public Form9 fm;
        public FormSC2()
        {
            InitializeComponent();
        }
        public FormSC2(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();

            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数

            SqlCommand MyCommand = new SqlCommand("select Snum from S;", conn); //定义一个数据库操作指令


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

            MyCommand = new SqlCommand("select Cnum from C;", conn); //定义一个数据库操作指令


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
            if (textBox1.Text == "" ||  comboBox1.Text == "" || comboBox2.Text == "")
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
                cmd.CommandText = "insert into SC values(@Snum,@Cnum,@Score)";
                cmd.Parameters.AddWithValue("@Score", textBox1.Text);
                
                cmd.Parameters.AddWithValue("@Snum", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cnum", comboBox2.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功！");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("添加失败！请输入正确的学生和课程！");
                    //根据ex.Number的值给出友好的错误信息
                }

                conn.Close();

            }
        }
    }
}
