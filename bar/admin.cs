using System;
using System.Collections;
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
    public partial class admin : Form
    {
        public  ArrayList index = new ArrayList();

        public int min(List<product_quantity> data)
        {
            float res = 320000000;
            foreach (product_quantity i in data)
            {
                if (i.product_container != null)
                if (i.quantity_c > 0)
                    if (res > i.product_container.quantity / i.quantity_c)
                        res = i.product_container.quantity / i.quantity_c;
            }
            return (int)res;

        }
        public admin()
        {
            InitializeComponent();
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
           foreach(order i in DB.data_BD.orders)
           {
               if (i.User!=null)
           dataGridView1.Rows.Add(i.User.login,i.price,i.date.ToString("dd MMMM yyyy | HH:mm:ss"));
           }
            update();
        }
        void update()
        {
            index.Clear();
            dataGridView3.Rows.Clear();
            foreach (container i in DB.data_BD.containers)
            {
                index.Add(i.ContainerId);
                dataGridView3.Rows.Add(i.tape, i.price, i.time, min(i.composition));

            }
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            product_f start = new product_f();
            start.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cocktail start = new cocktail(new cocktail_create());
            start.ShowDialog();
            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                container del = DB.data_BD.containers.Find(index[dataGridView3.CurrentRow.Index]);
                if (del.composition != null)
                {
                    DB.data_BD.containers.Remove(del);
                    DB.data_BD.SaveChanges();
                }
                update();
            }
            catch(System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Ошибка удаления");
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cocktail start = new cocktail(new cocktail_change((int)index[dataGridView3.CurrentRow.Index]));
            start.ShowDialog();
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_work start = new User_work();
            start.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (order i in DB.data_BD.orders)
            {
                if (i.User != null)
                    dataGridView1.Rows.Add(i.User.login, i.price, i.date.ToString("dd MMMM yyyy | HH:mm:ss"));
            }
        }
    }
}
