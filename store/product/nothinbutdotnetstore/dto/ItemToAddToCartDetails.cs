using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.dto
{
    public class ItemToAddToCartDetails
    {
        public Id<long> product_id;
        public int quantity;
    }
}