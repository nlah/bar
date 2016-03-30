using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bar
{
  public interface cocktail_B
    {
      void save(DataGridView dataGridView2, string textBox1, string textBox2, string textBox3);
      void create(DataGridView dataGridView1, DataGridView dataGridView2, TextBox price, TextBox tape, TextBox time);

    }
   public class cocktail_create : cocktail_B
  {
       public void save(DataGridView dataGridView2, string textBox1, string textBox2, string textBox3)
    {
        try
        {

            List<product_quantity> data = new List<product_quantity>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                product_quantity DAT = new product_quantity();
                DAT.product_container = DB.data_BD.products.Find(row.Cells[4].Value);
                DAT.quantity_c = float.Parse(row.Cells[3].Value.ToString());
                data.Add(DAT);
            }

            container d = new container();
            d.price = float.Parse(textBox2);
            d.tape = textBox1;
            d.time = float.Parse(textBox3);
            d.composition = data;

            DB.data_BD.containers.Add(d);
            DB.save();

        }
        catch (System.FormatException)
        {
            MessageBox.Show("Ошибка ввода");
        }
    
    }
       public void create(DataGridView dataGridView1, DataGridView dataGridView2, TextBox price, TextBox tape, TextBox time)
       {
           DB_and_dataGridView_product.updata(dataGridView1);
       }
  }
   public class cocktail_change : cocktail_B
   {
       int index;
       public cocktail_change(int index)
       {
           this.index = index;
       }
       public void save(DataGridView dataGridView2, string textBox1, string textBox2, string textBox3)
       {
           try
           {
             DB.data_BD.containers.Remove(DB.data_BD.containers.Find(index));
               List<product_quantity> data = new List<product_quantity>();
               foreach (DataGridViewRow row in dataGridView2.Rows)
               {
                   product_quantity DAT = new product_quantity();
                   DAT.product_container = DB.data_BD.products.Find(row.Cells[4].Value);
                   DAT.quantity_c = float.Parse(row.Cells[3].Value.ToString());
                   data.Add(DAT);
               }

               container d = new container();
               d.price = float.Parse(textBox2);
               d.tape = textBox1;
               d.time = float.Parse(textBox3);
               d.composition = data;

               DB.data_BD.containers.Add(d);
               DB.save();

           }
           catch (System.FormatException)
           {
               MessageBox.Show("Ошибка ввода");
           }

       }
       public void create(DataGridView dataGridView1, DataGridView dataGridView2, TextBox price, TextBox tape, TextBox time)
       {
          DB_and_dataGridView_product.updata(dataGridView1);
          container data= DB.data_BD.containers.Find(index);
          price.Text = data.price.ToString(); tape.Text = data.tape.ToString();

          time.Text = data.time.ToString();
           foreach (product_quantity i in data.composition)
           {
               if (i.product_container != null)
                   dataGridView2.Rows.Add(i.product_container.Name, i.product_container.tape, i.product_container.price, i.quantity_c, i.product_container.ProductsId);
           }
           
       }
   }
}
