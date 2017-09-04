using NHibernate;
using SportsStore.Domain;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Sesion;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace SportsStore.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISession _session;
        public ProductRepository(ISession session)
        {
            _session = session;
        }

        public ProductRepository()
        {
            _session = SesionFactoryUpdate.GetSession();/// initializam sesiunea....
        }

        public IEnumerable<Product> GetByID(int i)
        {
            return _session.QueryOver<Product>().Where(x => x.ProductID == i).List();
        }

        public IEnumerable<Product> GettAll()
        {
            return _session.QueryOver<Product>().List();
        }
        public int PageSize = 4;
        public string categ;
        public IEnumerable<Product>  Pagin(int page, string _categ)
        {///, string categ="chess"
            page = 1;
            categ = _categ;
            return _session.QueryOver<Product>().Where(t => _categ== null || t.Category == _categ)
                .OrderBy(t => t.ProductID).Asc.Skip((page-1)* PageSize).Take(PageSize).List<Product>();
            ///Where(t=> categ != null || t.Category==categ)
        }
        public IEnumerable<String> GetCategory()
        {

            var rez = _session.QueryOver<Product>().SelectList(list
                 => list.Select(x => x.Category)).List<string>();
            return rez.Distinct();
        }



        int IProductRepository.Count()
        {
            return _session.QueryOver<Product>().RowCount();
        }
    }
}
