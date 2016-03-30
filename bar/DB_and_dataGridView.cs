using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bar
{
    public sealed class DB
    {
        public static User User_it=null;
        public static bar_BD data_BD = new bar_BD();
        static DB()
        {
            foreach (product_quantity i in DB.data_BD.product_quantitys) ;
            foreach (product i in DB.data_BD.products) ;
            foreach (User i in DB.data_BD.Users) ;

        }
        public static void save()
        {
            try
            {
                data_BD.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Ошибка сохранения");
            }
            
        }
    }
    public sealed class DB_and_dataGridView_product
    {
        public static ArrayList index = new ArrayList();
        static DB_and_dataGridView_product()
        {
            foreach (product i in DB.data_BD.products)index.Add(i.ProductsId);
        }
        public static void delete(DataGridView dataGridView1)
        {
            product del = DB.data_BD.products.Find(index[dataGridView1.CurrentRow.Index]);
            DB.data_BD.products.Remove(del);
            DB.save();
           /* updata(dataGridView1);*/
        }

        public static void updata(DataGridView dataGridView1)
        {
          

                index.Clear();
                
            dataGridView1.Rows.Clear();
          /*      while (dataGridView1.Rows.Count != 0)
                    dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.Rows.Count - 1]);*/
            foreach (product i in DB.data_BD.products)
                {
                    index.Add(i.ProductsId);
                    dataGridView1.Rows.Add(i.Name, i.tape, i.price, i.quantity);
                }
        }
        public static void updata_data(DataGridView dataGridView1, Dictionary<int, List<product>> Data)
        {
            List<product> data = new List<product>();
            int i = 0;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells == null)
                    break;
                product d = DB.data_BD.products.Find(index[i]);
                d.Name = row.Cells[0].Value.ToString();
                d.price = decimal.Parse(row.Cells[2].Value.ToString());
                d.tape = row.Cells[1].Value.ToString();
                d.quantity = int.Parse(row.Cells[3].Value.ToString());
                try
                {
                    d.similar = Data[i];
                }
                catch (KeyNotFoundException)
                { }
                DB.data_BD.Entry(d).State = EntityState.Modified;
                i++;
            }
            DB.save();
           /* updata(dataGridView1);*/
        }
 
        public static void ADD(DataGridView dataGridView1, Dictionary<int, List<product>> Data)
        {
            List<product> data = new List<product>();
            int i=0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                    break;
                product d = new product();
                d.Name = row.Cells[0].Value.ToString();
                d.price = decimal.Parse(row.Cells[2].Value.ToString());
                d.tape = row.Cells[1].Value.ToString();
                d.quantity = int.Parse(row.Cells[3].Value.ToString());
                try
                {
                    d.similar = Data[i];
                }
                catch (KeyNotFoundException)
                { }
                DB.data_BD.products.Add(d);
                i++;
            }

            DB.save();
        }
        public static void carry(DataGridView dataGridView1, DataGridView dataGridView2,int ID=-1)
        {
            dataGridView2.Rows.Add(dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[1].Value, dataGridView1.CurrentRow.Cells[2].Value, dataGridView1.CurrentRow.Cells[3].Value, ID);
        }
    }
}
