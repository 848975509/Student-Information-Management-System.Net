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
    public partial class FormSC3 : Form
    {
        public Form9 fm;
        public FormSC3()
        {
            InitializeComponent();
        }
        public FormSC3(Form9 tfm)
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

            MyCommand = new SqlCommand("select Cname from C;", conn); //定义一个数据库操作指令


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
            String Cnum = "";

            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            conn.Open();
            SqlCommand MyCommand2 = new SqlCommand("select Cnum from C where Cname=@Cname;", conn); //定义一个数据库操作指令
            MyCommand2.Parameters.AddWithValue("@Cname", comboBox2.Text);

            SqlDataAdapter SelectAdapter2 = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter2.SelectCommand = MyCommand2;//定义数据适配器的操作指令
            DataSet MyDataSet2 = new DataSet();//定义一个数据集
            SelectAdapter2.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter2.Fill(MyDataSet2);//填充数据集

            DataTable table2 = MyDataSet2.Tables[0]; //查询第一张表



            for (int i = 0; i < table2.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {

                DataRow row = table2.Rows[i];    //遍历每一行,得到每一行的内容
                Cnum = row[0].ToString();
            }

            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("输入不得为空！");
            }
            else if (Cnum == "")
            {
                MessageBox.Show(" 无此课程！");
            }
            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update SC set Score=@Score where Snum=@Snum AND Cnum=@Cnum;";

                cmd.Parameters.AddWithValue("@Score", textBox1.Text);
                cmd.Parameters.AddWithValue("@Snum", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cnum", Cnum);

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("修改成功！");

                else
                    MessageBox.Show("修改失败！无此学生 或 无此课程 或 学生没选修此课！");
                //根据ex.Number的值给出友好的错误信息
            }

            conn.Close();
        }
    }
}
