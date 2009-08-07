using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public class CatalogTasksImplementation : CatalogTasks
    {
        DepartmentRepository department_repository;
        ProductRepository  product_repository;
        readonly DomainToModelMapper mapper;

        public CatalogTasksImplementation(DepartmentRepository department_repository, ProductRepository product_repository, DomainToModelMapper mapper)
        {
            this.department_repository = department_repository;
            this.product_repository = product_repository;
            this.mapper = mapper;
        }

        public IEnumerable<DepartmentItem> get_all_main_departments()
        {
            return department_repository.all_main_departments().Select(department => mapper.map<Department,DepartmentItem>(department));
        }

        public IEnumerable<DepartmentItem> get_all_subdepartments_in(Id<long> department_id)
        {
            return department_repository.all_sub_departments_in(department_id).Select(department => mapper.map<Department,DepartmentItem>(department));
        }

        public IEnumerable<ProductItem> get_all_products_in(Id<long> department_id)
        {
            return product_repository.all_products_in(department_id).Select(product => mapper.map<Product,ProductItem>(product));
        }
    }
}