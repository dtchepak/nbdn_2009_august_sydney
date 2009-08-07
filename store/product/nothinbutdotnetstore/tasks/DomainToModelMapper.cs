using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.tasks
{
    public interface DomainToModelMapper
    {
        Model map<Domain, Model>(Domain department);
    }
}