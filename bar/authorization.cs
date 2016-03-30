using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bar
{
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User User_s = DB.data_BD.Users.Find(textBox1.Text);
                if (User_s.password == textBox2.Text)
                { DB.User_it = User_s; this.Close(); }
                else throw new System.NullReferenceException();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Ошибка ввода");
            }
            catch (System.TypeInitializationException)
            {
                MessageBox.Show(textBox1.Text);

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
