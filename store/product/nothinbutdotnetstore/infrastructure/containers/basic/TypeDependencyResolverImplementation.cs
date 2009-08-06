using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class TypeDependencyResolverImplementation : TypeDependencyResolver
    {
        IDictionary<Type, Type> mappings = new Dictionary<Type, Type>();

        public T resolve_concrete_type<T>() {
            return (T) resolve_concrete_type(typeof(T));

        }
        public object resolve_concrete_type(Type type_of_class_to_resolve)
        {
            var type_to_create = mappings[type_of_class_to_resolve];
            return Activator.CreateInstance(type_to_create);
        }

        public void add_mapping(Type map_from, Type map_to) { 
            mappings.Add(map_from, map_to);
        }
    }
}