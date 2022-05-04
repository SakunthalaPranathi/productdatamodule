using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using productdatamodule.Models;

namespace productdatamodule.Models
{
    public class category
    {
        public int id { get; set; }
        public string categoryname{ get; set; }
        public string description { get; set; }
        public string status { get; set; }
    }
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext>options):base(options)
        {

        }
        public DbSet<category> category { get; set; }
        public DbSet<productdatamodule.Models.cart> cart { get; set; }
        public DbSet<productdatamodule.Models.discount> discount { get; set; }
        public DbSet<productdatamodule.Models.food> food { get; set; }
        public DbSet<productdatamodule.Models.inventory> inventory { get; set; }
        public DbSet<productdatamodule.Models.productsold> productsold { get; set; }
        public DbSet<productdatamodule.Models.sale> sale { get; set; }

    }
}
