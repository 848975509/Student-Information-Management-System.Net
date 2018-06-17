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
    public partial class FormS3 : Form
    {
        public Form9 fm;
        public FormS3()
        {
            InitializeComponent();
        }
        public FormS3(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
            this.comboBox1.Items.Clear();

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

            

            this.comboBox3.Items.Clear();


            SqlCommand MyCommand3 = new SqlCommand("select CLname from CL;", conn); //定义一个数据库操作指令


            SqlDataAdapter SelectAdapter3 = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter3.SelectCommand = MyCommand3;//定义数据适配器的操作指令
            DataSet MyDataSet3 = new DataSet();//定义一个数据集
            //conn.Open();//打开数据库连接
            SelectAdapter3.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter3.Fill(MyDataSet3);//填充数据集

            DataTable table3 = MyDataSet3.Tables[0]; //查询第一张表



            for (int i = 0; i < table3.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {

                DataRow row = table3.Rows[i];    //遍历每一行,得到每一行的内容
                this.comboBox3.Items.Add(row[0].ToString());
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
            String CLnum="";

            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            conn.Open();
            SqlCommand MyCommand2 = new SqlCommand("select CLnum from CL where CLname=@CLname;", conn); //定义一个数据库操作指令
            MyCommand2.Parameters.AddWithValue("@CLname", comboBox3.Text);

            SqlDataAdapter SelectAdapter2 = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter2.SelectCommand = MyCommand2;//定义数据适配器的操作指令
            DataSet MyDataSet2 = new DataSet();//定义一个数据集
            SelectAdapter2.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter2.Fill(MyDataSet2);//填充数据集

            DataTable table2 = MyDataSet2.Tables[0]; //查询第一张表



            for (int i = 0; i < table2.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {

                DataRow row = table2.Rows[i];    //遍历每一行,得到每一行的内容
                CLnum = row[0].ToString();
            }

            if(textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" ||  textBox4.Text=="" ||comboBox1.Text==""  || comboBox3.Text == "")
            {
                MessageBox.Show("输入不得为空！");
            }
            else if(CLnum=="")
            {
                MessageBox.Show(" 无此班级！");
            }
            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update S set Sname=@Sname,Ssex=@Ssex,Sphone=@Sphone,Sage=@Sage,CLnum=@CLnum where Snum=@Snum;";

                cmd.Parameters.AddWithValue("@Snum", comboBox1.Text);
                cmd.Parameters.AddWithValue("@CLnum", CLnum);
                cmd.Parameters.AddWithValue("@Sname", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ssex", textBox2.Text);
                cmd.Parameters.AddWithValue("@Sphone", textBox3.Text);
                cmd.Parameters.AddWithValue("@Sage", textBox4.Text);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败!无此学生！");
                }
                
            }

            conn.Close();
        }
    }
}
