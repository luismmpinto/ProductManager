using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class ProductManagerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProductManagerContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LuisPinto\Documents\Visual Studio 2017\Projects\ProductManager\ProductManager\App_Data\Productdb.mdf;Integrated Security=True;Connect Timeout=30")
        {
        }

        public System.Data.Entity.DbSet<ProductManager.Models.ProductsModel> Products { get; set; }
    }
}
