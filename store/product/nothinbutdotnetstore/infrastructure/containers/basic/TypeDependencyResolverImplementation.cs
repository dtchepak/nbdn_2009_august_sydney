using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class TypeDependencyResolverImplementation : TypeDependencyResolver
    {
        public T resolve_concrete_type<T>() {
            throw new NotImplementedException();

        }
        public object resolve_concrete_type(Type type_of_class_to_resolve)
        {
            throw new NotImplementedException();
        }

        public void add_mapping(Type map_from, Type map_to) { 
        }
    }
}