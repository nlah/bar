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
    public partial class User_work : Form
    {
        public User_work()
        {
            InitializeComponent();
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            foreach (User i in DB.data_BD.Users)
            {
                    dataGridView2.Rows.Add(i.login, i.salary,i.qualification,i.role);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try{
                if (textBox2.Text == textBox3.Text)
                {
                    User pers = new User(); pers.login = textBox1.Text; pers.role = 1; pers.qualification = int.Parse(textBox5.Text);
                    pers.password = textBox2.Text; pers.salary = decimal.Parse(textBox4.Text);
                    DB.data_BD.Users.Add(pers);
                    DB.save();
                    dataGridView2.Rows.Clear();
                    foreach (User i in DB.data_BD.Users)
                    {

                        dataGridView2.Rows.Add(i.login, i.salary, i.qualification,i.role);
                    }
                }
                else { MessageBox.Show("Ошибка ввода"); }
               }
            catch (System.FormatException)
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            User del = DB.data_BD.Users.Find(dataGridView2.CurrentRow.Cells[0].Value);
            DB.data_BD.Users.Remove(del);
            DB.save();
            dataGridView2.Rows.Clear();
            foreach (User i in DB.data_BD.Users)
            {
                dataGridView2.Rows.Add(i.login, i.salary, i.qualification, i.role);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
