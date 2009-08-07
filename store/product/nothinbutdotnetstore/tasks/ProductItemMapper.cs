using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public interface ProductItemMapper : Mapper<Product,ProductItem>
    {
    }
}