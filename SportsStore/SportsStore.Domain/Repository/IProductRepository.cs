using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GettAll();
        IEnumerable<Product> GetByID(int i);
        IEnumerable<Product> Pagin(int page,string str);
        int Count();
        IEnumerable<string> GetCategory();
    }
}
