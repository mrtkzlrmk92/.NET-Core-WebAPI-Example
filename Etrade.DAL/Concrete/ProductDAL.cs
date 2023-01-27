using Etrade.Business.Concrete;
using Etrade.DAL.Abstract;
using Etrade.Entities.Context;
using Etrade.Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.DAL.Concrete
{
    public class ProductDAL:Repository<Product,EtradeDbContext>,IProductDAL
    {
    }
}
