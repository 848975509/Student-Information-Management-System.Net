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
    public partial class Form4 : Form
    {
        public Form2 fm;
        String ID;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(Form2 tfm,String ID)
        {
            this.ID = ID;
            fm = tfm;
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7(this,ID);
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();//定义一个数据连接实例
            conn.ConnectionString = @"Server=.;DataBase=学生信息管理系统;Integrated Security=true";
            //定义数据库连接参数


            SqlCommand MyCommand = new SqlCommand("SELECT UserID,UserPW,Uname,Uphone,Umail FROM U;", conn); //定义一个数据库操作指令
            SqlDataAdapter SelectAdapter = new SqlDataAdapter();//定义一个数据适配器
            SelectAdapter.SelectCommand = MyCommand;//定义数据适配器的操作指令
            DataSet MyDataSet = new DataSet();//定义一个数据集
            conn.Open();//打开数据库连接
            SelectAdapter.SelectCommand.ExecuteNonQuery();//执行数据库查询指令

            SelectAdapter.Fill(MyDataSet);//填充数据集

            DataTable table = MyDataSet.Tables[0]; //查询第一张表
            
            DataRow row;
            int j = 0;
            for (int i = 0; i < table.Rows.Count; i++)  //遍历每一行,DataTable包含若干个行
            {
                row = table.Rows[i];    //遍历每一行,得到每一行的内容
                if (row[0].ToString() == ID)
                {
                    j = i;
                    break;
                }
            }
            row = table.Rows[j];
            Form5 frm = new Form5(this,row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            this.Hide();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6(this);
            this.Hide();
            frm.Show();
        }
    }
}
