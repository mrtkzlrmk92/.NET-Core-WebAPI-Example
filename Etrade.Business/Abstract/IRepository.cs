using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Business.Abstract
{
    public interface IRepository<Tentity>
        where Tentity : class
    {
        public List<Tentity> GetAll(Expression<Func<Tentity,bool>> filter = null);
        public Tentity Get(int id); 
        public Tentity Get(Expression<Func<Tentity, bool>> filter);

        void Add(Tentity entity);
        public void Update(Tentity entity);
        public void Delete(int id);
        public void Delete(Tentity entity);
    }
}
