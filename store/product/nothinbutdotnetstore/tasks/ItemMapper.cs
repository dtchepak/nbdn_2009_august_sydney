namespace nothinbutdotnetstore.tasks
{
    public interface ItemMapper<Source, DestinationItem> {
        DestinationItem map_from(Source source);
    }
}