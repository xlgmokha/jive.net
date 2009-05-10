using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Utility.Core
{
    public class NotSpecificationSpecs
    {
    }

    [Concern(typeof (NotSpecification<>))]
    public class when_checking_if_a_condition_is_not_met : concerns_for<ISpecification<int>, NotSpecification<int>>
    {
        static protected ISpecification<int> criteria;

        context c = () => { criteria = the_dependency<ISpecification<int>>(); };

        public override ISpecification<int> create_sut()
        {
            return new NotSpecification<int>(criteria);
        }
    }

    [Concern(typeof (NotSpecification<>))]
    public class when_a_condition_is_not_met : when_checking_if_a_condition_is_not_met
    {
        context c = () => when_the(criteria).is_told_to(x => x.is_satisfied_by(1)).it_will_return(false);

        because b = () => { result = sut.is_satisfied_by(1); };

        it should_return_true = () => result.should_be_true();

        static bool result;
    }

    [Concern(typeof (NotSpecification<>))]
    public class when_a_condition_is_met : when_checking_if_a_condition_is_not_met
    {
        context c = () => when_the(criteria).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);

        because b = () => { result = sut.is_satisfied_by(1); };

        it should_return_false = () => result.should_be_false();

        static bool result;
    }
}