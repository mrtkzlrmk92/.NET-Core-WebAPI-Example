using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entities.Models
{
    public class Product
    {

        public int Id { get; set; }//PK
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Product()
        {
            Category= new Category();
        }
    }
}
