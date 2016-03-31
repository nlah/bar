using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bar
{
    public  class product
    {
        [Key]
        public int ProductsId { get; set; }
      [Index(IsUnique = true)]
       [MaxLength(100)]
        public string Name { get; set; }
         [Required]
        public decimal price { get; set; }
         [Required]
        public string tape { get; set; }
         [Required]
        public float quantity { get; set; }
        public virtual List<product> similar { get; set; } 

    }
    public class product_quantity
    {
        [Key]
        public int product_quantityId { get; set; }
         [Required]
        public float quantity_c { get; set; }

        public virtual container containerObj { get; set; }
        public virtual product product_container { get; set; } 

    }
    public class container
    {
        [Key] 
        public int ContainerId { get; set; }
        public string tape { get; set; }
         [Required]
        public float time { get; set; }
         [Required]
        public float price { get; set; }
         [Required]
        public List<product_quantity> composition { get; set; } 
    }
    public class container_quantity
    {
        [Key]
        public int container_quantityid { get; set; }
         [Required]
        public float quantity { get; set; }


         [Required]
        public virtual container composition { get; set; } 
    }

    public class order
    {
        [Key]
        public int orderId { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public decimal tip { get; set; }
        public User User { get; set; }
        [Required]
        public virtual List<container_quantity> composition { get; set; } 

    }
    public class User
    {
          [Key]
          [MaxLength(20)]
          public string login { get; set; }
           [Required]
          public string password { get; set; }
           [Required]
          public int role { get; set; }
           [Required]
          public decimal salary { get; set; }
          public int qualification { get; set; }
    }
    public class bar_BD : DbContext
    {
        public bar_BD(): base("DbConnection"){ }
        public DbSet<product> products { get; set; }
        public DbSet<product_quantity> product_quantitys { get; set; }
        public DbSet<container_quantity> container_quantitys { get; set; }
        public DbSet<container> containers { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<User> Users { get; set; }
    }


}
