using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProductManager.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}//This is the model used for the creation of the database