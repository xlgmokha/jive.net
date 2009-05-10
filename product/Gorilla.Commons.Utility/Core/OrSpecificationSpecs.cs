using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Utility.Core
{
    [Concern(typeof (OrSpecification<>))]
    public abstract class when_checking_if_one_of_two_conditions_are_met : concerns_for<ISpecification<int>, OrSpecification<int>>
    {
        public override ISpecification<int> create_sut()
        {
            return new OrSpecification<int>(left, right);
        }

        context c = () =>
                        {
                            left = an<ISpecification<int>>();
                            right = an<ISpecification<int>>();
                        };

        protected static ISpecification<int> left;
        protected static ISpecification<int> right;
    }

    [Concern(typeof (OrSpecification<>))]
    public class when_one_of_the_conditions_is_met : when_checking_if_one_of_two_conditions_are_met
    {
        it should_return_true = () => result.should_be_true();

        context c = () => when_the(left).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
        because b = () => { result = sut.is_satisfied_by(1); };

        static bool result;
    }

    [Concern(typeof (OrSpecification<>))]
    public class when_the_second_condition_is_met : when_checking_if_one_of_two_conditions_are_met
    {
        it should_return_true = () => result.should_be_true();

        context c = () => when_the(right).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
        because b = () => { result = sut.is_satisfied_by(1); };

        static bool result;
    }

    [Concern(typeof (OrSpecification<>))]
    public class when_neither_conditions_are_met : when_checking_if_one_of_two_conditions_are_met
    {
        it should_return_false = () => result.should_be_false();

        because b = () => { result = sut.is_satisfied_by(1); };

        static bool result;
    }
}