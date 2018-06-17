using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    
    public partial class Form5 : Form
    {
        
        public Form4 fm;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(Form4 tfm,String ID,String PW,String Uname,String Uphone,String Umail)
        {
            fm = tfm;
            InitializeComponent();
            label7.Text = ID;
            label8.Text = PW;
            label9.Text = Uname;
            label10.Text = Uphone;
            label11.Text = Umail;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }
    }
}
