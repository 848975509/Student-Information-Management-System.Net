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
    public partial class FormS1 : Form
    {
        public Form9 fm;
        public FormS1()
        {
            InitializeComponent();
        }
        public FormS1(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数

            SqlCommand MyCommand = new SqlCommand("select S.Snum,Sname,Ssex,Sage,Dname,CLname,Sphone from S,D,CL where S.Dnum=D.Dnum AND S.CLnum=CL.CLnum ;", conn); //定义一个数据库操作指令
            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令
            conn.Close();//关闭数据库
            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表

            listView1.Columns.Add("学号");
            listView1.Columns.Add("姓名");
            listView1.Columns.Add("性别");
            listView1.Columns.Add("年龄");
            listView1.Columns.Add("专业");
            listView1.Columns.Add("班级");
            listView1.Columns.Add("电话");

            listView1.Columns[0].Width = 150;
            listView1.Columns[4].Width = 80;
            listView1.Columns[5].Width = 100;
            listView1.Columns[6].Width = 150;
            bool flag = false;
            for (int i = 0; i < table.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {
                DataRow row = table.Rows[i];    //遍历每一行,得到每一行的内容
                if (row[0].ToString() == textBox1.Text)
                {
                    flag = true;
                    ListViewItem lt = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    lt.Text = row[0].ToString();
                    for (int j = 1; j < table.Columns.Count; j++)    //遍历row的列
                    {
                        lt.SubItems.Add(row[j].ToString());
                        //将lt数据添加到listView1控件中
                    }
                    listView1.Items.Add(lt);
                }

            }
            if (!flag) MessageBox.Show("请输入正确的学号！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数

            SqlCommand MyCommand = new SqlCommand("select S.Snum,Sname,Ssex,Sage,Dname,CLname,Sphone from S,D,CL where S.Dnum=D.Dnum AND S.CLnum=CL.CLnum ;", conn); //定义一个数据库操作指令
            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令
            conn.Close();//关闭数据库
            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表

            listView1.Columns.Add("学号");
            listView1.Columns.Add("姓名");
            listView1.Columns.Add("性别");
            listView1.Columns.Add("年龄");
            listView1.Columns.Add("专业");
            listView1.Columns.Add("班级");
            listView1.Columns.Add("电话");

            listView1.Columns[0].Width = 130;
            listView1.Columns[4].Width = 80;
            listView1.Columns[5].Width = 100;
            listView1.Columns[6].Width = 130;
            //bool flag = false;
            for (int i = 0; i < table.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {
                DataRow row = table.Rows[i];    //遍历每一行,得到每一行的内容

                ListViewItem lt = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                lt.Text = row[0].ToString();
                for (int j = 1; j < table.Columns.Count; j++)    //遍历row的列
                {
                    lt.SubItems.Add(row[j].ToString());
                    //将lt数据添加到listView1控件中
                }
                listView1.Items.Add(lt);

            }
        }
    }
}
