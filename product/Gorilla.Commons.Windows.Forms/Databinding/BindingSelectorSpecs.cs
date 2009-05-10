using System;
using System.Linq.Expressions;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public class BindingSelectorSpecs
    {
    }

    [Concern(typeof (BindingSelector<>))]
    public class when_selecting_a_property_as_the_target_of_a_binding : concerns_for<IBindingSelector<IAnInterface>>
    {
        it should_return_a_binder_bound_to_the_correct_property =
            () => result.property.Name.should_be_equal_to("FirstName");

        it should_inspect_the_expression_for_the_property_information =
            () => inspector.was_told_to(i => i.inspect(expression_to_parse));

        context c = () =>
                        {
                            thing_to_bind_to = an<IAnInterface>();
                            factory = an<IPropertyInspectorFactory>();
                            inspector = an<IPropertyInspector<IAnInterface, string>>();

                            factory.is_told_to(f => f.create<IAnInterface, string>()).it_will_return(inspector);

                            inspector.is_told_to(i => i.inspect(null))
                                .IgnoreArguments().it_will_return(typeof (IAnInterface).GetProperty("FirstName"));
                        };

        because b = () =>
                        {
                            expression_to_parse = (s => s.FirstName);
                            result = sut.bind_to_property(expression_to_parse);
                        };

        public override IBindingSelector<IAnInterface> create_sut()
        {
            return new BindingSelector<IAnInterface>(thing_to_bind_to, factory);
        }

        static IAnInterface thing_to_bind_to;
        static IPropertyBinder<IAnInterface, string> result;
        static IPropertyInspectorFactory factory;
        static IPropertyInspector<IAnInterface, string> inspector;
        static Expression<Func<IAnInterface, string>> expression_to_parse;
    }
}