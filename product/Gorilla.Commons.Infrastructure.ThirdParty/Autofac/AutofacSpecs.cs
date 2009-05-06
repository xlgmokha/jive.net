using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Modules;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Autofac
{
    public class when_trying_to_register_a_single_item_in_the_autofac_container : concerns
    {
        it should_resolve_that_item = () => result.should_be_an_instance_of<A>();

        context c = () =>
                        {
                            builder = new ContainerBuilder();
                            builder.Register<A>().As<ITestItem>().FactoryScoped();
                            container = builder.Build();
                        };

        because b = () => { result = container.Resolve<ITestItem>(); };

        after_each_observation after_each = () => container.Dispose();

        static ContainerBuilder builder;
        static IContainer container;
        static ITestItem result;
    }

    public class when_trying_to_resolve_all_the_components_that_implement_a_common_interface : concerns
    {
        it should_return_each_component = () =>
                                              {
                                                  results.Count().should_be_equal_to(2);
                                                  results.First().should_be_an_instance_of<A>();
                                                  results.Skip(1).First().should_be_an_instance_of<B>();
                                              };

        context c = () =>
                        {
                            builder = new ContainerBuilder();
                            builder.RegisterModule(new ImplicitCollectionSupportModule());
                            builder.Register<A>().As<ITestItem>().FactoryScoped();
                            builder.Register<B>().As<ITestItem>().FactoryScoped();
                            container = builder.Build();
                        };

        because b = () => { results = container.Resolve<IEnumerable<ITestItem>>(); };

        after_each_observation after_each = () => container.Dispose();

        static ContainerBuilder builder;
        static IContainer container;
        static IEnumerable<ITestItem> results;
    }

    public interface ITestItem
    {
    }

    public class A : ITestItem
    {
    }

    public class B : ITestItem
    {
    }
}