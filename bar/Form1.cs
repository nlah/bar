using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections;

namespace bar
{
    public partial class Form1 : Form
    {
        public  ArrayList index = new ArrayList();
        public  ArrayList index_data = new ArrayList();        
        public int min(List<product_quantity> data)
        {
            float res = 320000000;
            if (data!=null)
            foreach (product_quantity i in data)
            {
                if (i.product_container != null)
                if (i.quantity_c > 0)
                    if (res > i.product_container.quantity / i.quantity_c)
                        res = i.product_container.quantity / i.quantity_c;
            }
            return (int)res;

        }
        public Form1()
        {
            InitializeComponent();
            index.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            foreach (container i in DB.data_BD.containers)
            {
                int M=min(i.composition);
                if(M>0)
                {
                index.Add(i.ContainerId);
                dataGridView1.Rows.Add(i.tape, i.price, i.time, M);
                }
            }
          if (DB.User_it.role != 0) button3.Enabled = false;
            using (var db = new bar_BD())
            {
                // Create and save a new Blog 
              //  var name = "Enter";
              //  var blog = new product { Name = name };
                //db.products.Add(blog);
               // order blogw = new order() { price = 2.5m };
               // db.orders.Add(blogw);
               // db.SaveChanges();
            }
        
        }
        public void dataGridView1_CellMouseDoubleClick(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[1].Value, 1);
            index_data.Add(dataGridView1.CurrentRow.Index);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            admin add = new admin();
            add.ShowDialog();
            index.Clear();
            dataGridView1.Rows.Clear();
            foreach (container i in DB.data_BD.containers)
            {
                index.Add(i.ContainerId);
                dataGridView1.Rows.Add(i.tape, i.price, i.time, min(i.composition));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                order data = new order();
                int j = 0; decimal price = 0;
                List<container_quantity> data_L = new List<container_quantity>();
                foreach (int i in index_data)
                {
                    container_quantity D = new container_quantity();
                    container PR = DB.data_BD.containers.Find(index[i]);
                    D.composition = PR;
                    price += (decimal)PR.price;
                    D.container_quantityid = int.Parse(dataGridView2.Rows[j].Cells[2].Value.ToString());
                    j++;
                }

                data.composition = data_L;

                data.price = price;
                data.tip = decimal.Parse(textBox1.Text);
                data.date = DateTime.Now;
                data.User = DB.User_it;
                DB.data_BD.orders.Add(data);
                DB.save();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ошибка ввода");
            }
          /*  data.composition*/
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
