using System;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.orm
{
    public class ProductQueries
    {
        static Criteria<Product> product_criteria = new FakeCriteria<Product>();

        static public Criteria<Product> identified_by(Id<long> id)
        {
            return product_criteria;
        }

        private class FakeCriteria<Item> :Criteria<Item>{

        }
    }
}