using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
    public class SpecificationExtensionsSpecs
    {
        public abstract class when_evaluating_two_conditions
        {
            Establish c = () =>
            {
                left = Create.an<Specification<int>>();
                right = Create.an<Specification<int>>();
            };

            static protected Specification<int> left;
            static protected Specification<int> right;
        }

        [Subject(typeof (SpecificationExtensions))]
        public class when_checking_if_two_conditions_are_met_and_they_are : when_evaluating_two_conditions
        {
            It should_return_true = () => result.should_be_true();

            Establish c = () =>
            {
                right.is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
                left.is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
            };

            Because b = () =>
            {
                result = left.or(right).is_satisfied_by(1);
            };

            static bool result;
        }

        [Subject(typeof (SpecificationExtensions))]
        public class when_checking_if_one_of_two_conditions_are_met_and_the_left_one_is_not : when_evaluating_two_conditions
        {
            It should_return_true = () => result.should_be_true();

            Establish c = () =>
            {
                right.is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
                left.is_told_to(x => x.is_satisfied_by(1)).it_will_return(false);
            };

            Because b = () =>
            {
                result = left.or(right).is_satisfied_by(1);
            };

            static bool result;
        }

        [Subject(typeof (SpecificationExtensions))]
        public class when_checking_if_one_of_two_conditions_are_met_and_the_right_one_is_not :
            when_evaluating_two_conditions
        {
            It should_return_true = () => result.should_be_true();

            Establish c = () =>
            {
                right.is_told_to(x => x.is_satisfied_by(1)).it_will_return(false);
                left.is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
            };

            Because b = () =>
            {
                result = left.or(right).is_satisfied_by(1);
            };

            static bool result;
        }
    }
}