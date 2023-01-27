using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entities.Models
{
    public class Category
    {
        
        public int Id { get; set; }

        [Display(Name ="Adı")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Category()
        {
            Products= new List<Product>();
        }
    }
}
