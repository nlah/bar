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
    public partial class cocktail : Form
    {
        cocktail_B build;
        public int min(List<product_quantity> data)
        {
            float res = 320000000;
                foreach (product_quantity i in data)
                {
                    if (i.quantity_c > 0)
                        if (res > i.product_container.quantity / i.quantity_c)
                            res = i.product_container.quantity / i.quantity_c;
                }
            
         
            return (int)res;

        }


        public cocktail(cocktail_B build)
        {
            this.build = build;
            InitializeComponent();
            button1.Text = "Сохранить";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            /* dataGridView2.ReadOnly = true;*/
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[4].ReadOnly = true;

            build.create(dataGridView1, dataGridView2, price, name, time);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);

            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
        }
        
        public void dataGridView1_CellMouseDoubleClick(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[1].Value, dataGridView1.CurrentRow.Cells[2].Value, 0, (int)DB_and_dataGridView_product.index[dataGridView1.CurrentRow.Index]);
        }
        public void dataGridView2_CellMouseDoubleClick(object sender, EventArgs e)
        {

            sim start = new sim(DB.data_BD.products.Find(dataGridView2.CurrentRow.Cells[4].Value));
            start.ShowDialog();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            build.save(dataGridView2, name.Text, price.Text, time.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
