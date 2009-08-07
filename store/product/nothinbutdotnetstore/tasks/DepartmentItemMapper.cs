using System;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentItemMapper : Mapper<Department, DepartmentItem>
    {
    }

    public class DepartmentItemMapperImplementation : DepartmentItemMapper
    {
        public DepartmentItem map_from(Department item)
        {
            throw new NotImplementedException();
        }
    }
}