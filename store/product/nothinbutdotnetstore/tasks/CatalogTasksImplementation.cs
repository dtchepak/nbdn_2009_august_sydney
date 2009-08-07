using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public class CatalogTasksImplementation : CatalogTasks
    {
        public MapperRegistry mapper_registry { get; set; }
        DepartmentRepository department_repository;
        ProductRepository  product_repository;
        ProductItemMapper product_item_mapper;
        
        public CatalogTasksImplementation(DepartmentRepository department_repository, MapperRegistry mapper_registry, ProductRepository product_repository, ProductItemMapper product_item_mapper)
        {
            this.mapper_registry = mapper_registry;
            this.department_repository = department_repository;
            this.product_item_mapper = product_item_mapper;
            this.product_repository = product_repository;
        }

        public IEnumerable<DepartmentItem> get_all_main_departments()
        {
            return department_repository.all_main_departments().Select(department => mapper_registry.get_mapper_to_map<Department,DepartmentItem>().map_from(department));
        }

        public IEnumerable<DepartmentItem> get_all_subdepartments_in(Id<long> department_id)
        {
            return department_repository.all_sub_departments_in(department_id).Select(department => mapper_registry.get_mapper_to_map<Department,DepartmentItem>().map_from(department));
        }

        public IEnumerable<ProductItem> get_all_products_in(Id<long> department_id)
        {
            return product_repository.all_products_in(department_id).Select(product => product_item_mapper.map_from(product));
        }
    }
}