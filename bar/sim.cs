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
    public partial class sim : Form
    {
        public sim(product data)
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            label1.Text = data.Name;
            foreach (product i in data.similar)
                {
                    dataGridView1.Rows.Add(i.Name, i.tape, i.price, i.quantity);
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
