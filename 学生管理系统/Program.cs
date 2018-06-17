using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    
    public class User
    {
        public String ID;
        public String PassWord;
        public String Name;
        public String Phone;
        public String Email;
        public User(String ID,String PassWord,String Name,String Phone,String Email)
        {
            this.ID = ID;
            this.PassWord = PassWord;
            this.Name = Name;
            this.Phone=Phone;
            this.Email = Email;
        }

        public User()
        {
        }

        public String getID()
        {
            return ID;
        }
        public String getPassWord()
        {
            return PassWord;
        }
        public String getName()
        {
            return Name;
        }
        public String getPhone()
        {
            return Phone;
        }
        public String getEmail()
        {
            return Email;
        }
    }
    
    static class Program
    {
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
