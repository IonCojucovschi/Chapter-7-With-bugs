using FluentNHibernate.Mapping;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Mapping
{
    public class ProductMap: ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ProductID).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            Map(x => x.Category).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
        }
    }
}
