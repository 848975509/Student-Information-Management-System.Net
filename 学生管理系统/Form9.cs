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
    public partial class Form9 : Form
    {
        public Form8 fm;
        public Form9()
        {
            InitializeComponent();
        }
        public Form9(Form8 tfm)
        {
            fm = tfm;
            InitializeComponent();
        }
        private void 管理员密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10(this);
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Show();
        }

        private void 查看密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 frm = new Form11(this);
            this.Hide();
            frm.Show();
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormS1 frm = new FormS1(this);
            this.Hide();
            frm.Show();
        }

        private void 学生个人信息添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormS2 frm = new FormS2(this);
            this.Hide();
            frm.Show();
        }

        private void 删除院系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormD3 frm = new FormD3(this);
            this.Hide();
            frm.Show();
        }

        private void 班级浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCL1 frm = new FormCL1(this);
            this.Hide();
            frm.Show();
        }

        private void 浏览院系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormD1 frm = new FormD1(this);  
            this.Hide();
            frm.Show();
        }

        private void 浏览课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormC1 frm = new FormC1(this);
            this.Hide();
            frm.Show();
        }

        private void 学生成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSC1 frm = new FormSC1(this);
            this.Hide();
            frm.Show(); 
        }

        private void 添加班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCL2 frm = new FormCL2(this);
            this.Hide();
            frm.Show();
        }

        private void 添加院系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormD2 frm = new FormD2(this);
            this.Hide();
            frm.Show();
        }

        private void 添加课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormC2 frm = new FormC2(this);
            this.Hide();
            frm.Show();
        }

        private void 学生成绩添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSC2 frm = new FormSC2(this);
            this.Hide();
            frm.Show();
        }

        private void 学生个人信息删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormS4 frm = new FormS4(this);
            this.Hide();
            frm.Show();
        }

        private void 删除班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCL4 frm = new FormCL4(this);
            this.Hide();
            frm.Show();
        }

        private void 删除院系ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormD4 frm = new FormD4(this);
            this.Hide();
            frm.Show();
        }

        private void 删除课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormC4 frm = new FormC4(this);
            this.Hide();
            frm.Show();
        }

        private void 学生成绩删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSC4 frm = new FormSC4(this);
            this.Hide();
            frm.Show();
        }

        private void 学生个人信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormS3 frm = new FormS3(this);
            this.Hide();
            frm.Show();
        }

        private void 修改班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCL3 frm = new FormCL3(this);
            this.Hide();
            frm.Show();
        }

        private void 修改课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormC3 frm = new FormC3(this);
            this.Hide();
            frm.Show();
        }

        private void 学生成绩修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSC3 frm = new FormSC3(this);
            this.Hide();
            frm.Show();
        }
    }
}
