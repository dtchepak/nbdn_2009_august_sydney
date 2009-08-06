 using System.Data;
 using System.Data.SqlClient;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class TypeDependencyResolverSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<TypeDependencyResolver,
                                             TypeDependencyResolverImplementation>
         {
        
         }

         [Concern(typeof(TypeDependencyResolverImplementation))]
         public class when_registering_a_mapping : concern
         {
             after_the_sut_has_been_created ac = () =>
             {
                 sut.add_mapping(typeof (IDbConnection), typeof (SqlConnection));
             };

             because b = () =>
             {
                 result = sut.resolve_concrete_type<IDbConnection>();
             };
        
             it should_be_able_to_resolve_a_dependency_of_mapped_type = () =>
             {
                 result.should_be_an_instance_of<SqlConnection>();
             };

             static IDbConnection result;
         }
     }
 }
