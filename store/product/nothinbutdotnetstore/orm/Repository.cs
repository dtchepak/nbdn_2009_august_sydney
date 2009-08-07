namespace nothinbutdotnetstore.orm
{
    public interface Repository
    {
        Item the_item_matching<Item>(Criteria<Item> criteria);
    }
}