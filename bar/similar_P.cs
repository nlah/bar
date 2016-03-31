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
    public partial class similar_P : Form
    {
       List<product>  data;
       ArrayList Data = new ArrayList();


        public similar_P(List<product> data)
        {
            this.data = data;
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            foreach (product i in data)
            {
                dataGridView2.Rows.Add(i.Name, i.tape, i.price, i.quantity, i.ProductsId);
            }
            DB_and_dataGridView_product.updata(dataGridView1);
        }
        public void dataGridView1_CellMouseDoubleClick(object sender, EventArgs e)
        {
            DB_and_dataGridView_product.carry(dataGridView1, dataGridView2, (int)DB_and_dataGridView_product.index[dataGridView1.CurrentRow.Index]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // int i =0;
            data.Clear();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                data.Add(DB.data_BD.products.Find(row.Cells[4].Value));
            //    i++;
            }
            this.Close();
        }
        public List<product> retrieve()
        {
            return data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
