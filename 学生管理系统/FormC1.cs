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
    public partial class FormC1 : Form
    {
        public Form9 fm;
        public FormC1()
        {
            InitializeComponent();
        }
        public FormC1(Form9 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

            SqlCommand MyCommand = new SqlCommand("select Cname,Cfreq from C;", conn); //定义一个数据库操作指令

            //MyCommand.Parameters.AddWithValue("@ID", textBox1.Text);

            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令
            conn.Close();//关闭数据库
            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表


            listView1.Columns.Add("课程");
            listView1.Columns.Add("学分");

            listView1.Columns[0].Width = 120;
            //listView1.Columns[1].Width = 80;

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

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数

            SqlCommand MyCommand = new SqlCommand("select Sname,S.Snum,Cname,Cfreq from C,S,SC where S.Snum=SC.Snum AND C.Cnum=SC.Cnum AND S.Snum=@ID;", conn); //定义一个数据库操作指令

            MyCommand.Parameters.AddWithValue("@ID", textBox1.Text);

            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令
            conn.Close();//关闭数据库
            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表

            listView1.Columns.Add("姓名");
            listView1.Columns.Add("学号");
            listView1.Columns.Add("课程");
            listView1.Columns.Add("学分");

            listView1.Columns[0].Width = 80;
            listView1.Columns[1].Width = 130;
            listView1.Columns[2].Width = 80;

            if (table.Rows.Count > 0)
            {
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
            else
            {
                MessageBox.Show("无结果！");
            }
        }
    }
}
