using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bar
{
    public partial class product_f : Form
    {
        Dictionary<int, List<product>> Data = new Dictionary<int, List<product>>();
        Dictionary<int, List<product>> product_similar = new Dictionary<int, List<product>>();

        public product_f()
        {
            InitializeComponent();
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            updata();
        }
        public void dataGridView1_CellMouseDoubleClick(object sender, EventArgs e)
        {
            product_similar.Clear();
            try
            {
                try
                {
                  
                    foreach (product i in DB.data_BD.products.Find(DB_and_dataGridView_product.index[dataGridView1.CurrentRow.Index]).similar)
                        product_similar[dataGridView1.CurrentRow.Index].Add(i);
                }
                catch (NullReferenceException)
                { }
                    similar_P add = new similar_P(product_similar[dataGridView1.CurrentRow.Index]);
                    add.ShowDialog();
                    if (add.retrieve() != null && dataGridView1.CurrentRow != null)
                        product_similar[dataGridView1.CurrentRow.Index] = add.retrieve();
                
            }
            catch (KeyNotFoundException)
            {
                List<product> D = new List<product>(DB.data_BD.products.Find(DB_and_dataGridView_product.index[dataGridView1.CurrentRow.Index]).similar);
                similar_P add = new similar_P(D);
                add.ShowDialog();
                product_similar[dataGridView1.CurrentRow.Index] = add.retrieve();
            }
        }

        public void updata()
        {
            DB_and_dataGridView_product.updata(dataGridView1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
     
            try
            {
                
                DB_and_dataGridView_product.updata_data(dataGridView1, product_similar);
                DB_and_dataGridView_product.updata(dataGridView1);
                product_similar.Clear();
            }
            catch(System.FormatException )
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            product_similar.Clear();
            DB_and_dataGridView_product.updata(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DB_and_dataGridView_product.ADD(dataGridView2, Data);
                    button4_Click(sender, e);
                    DB_and_dataGridView_product.updata(dataGridView1);

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                 Data.Clear();
                dataGridView2.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB_and_dataGridView_product.delete(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                similar_P add = new similar_P(Data[dataGridView2.CurrentRow.Index]);
                add.Show();
                Data[dataGridView2.CurrentRow.Index] = add.retrieve();
            }
            catch (KeyNotFoundException)
            {
                similar_P add = new similar_P(new List<product>());
                add.ShowDialog();
                Data[dataGridView2.CurrentRow.Index] = add.retrieve();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не выделено");
            }
 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
