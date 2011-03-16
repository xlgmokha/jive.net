using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
    public class OrSpecificationSpecs
    {
        [Subject(typeof (OrSpecification<>))]
        public abstract class when_checking_if_one_of_two_conditions_are_met
        {
            static Specification<int> create_sut()
            {
                return new OrSpecification<int>(left, right);
            }

            Establish c = () =>
            {
                left = Create.an<Specification<int>>();
                right = Create.an<Specification<int>>();
                sut = create_sut();
            };

            static protected Specification<int> left;
            static protected Specification<int> right;
            static protected Specification<int> sut;
        }

        [Subject(typeof (OrSpecification<>))]
        public class when_one_of_the_conditions_is_met : when_checking_if_one_of_two_conditions_are_met
        {
            It should_return_true = () => result.should_be_true();

            Establish c = () => left.is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);

            Because b = () =>
            {
                result = sut.is_satisfied_by(1);
            };

            static bool result;
        }

        [Subject(typeof (OrSpecification<>))]
        public class when_the_second_condition_is_met : when_checking_if_one_of_two_conditions_are_met
        {
            It should_return_true = () => result.should_be_true();

            Establish c = () => right.is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);

            Because b = () =>
            {
                result = sut.is_satisfied_by(1);
            };

            static bool result;
        }

        [Subject(typeof (OrSpecification<>))]
        public class when_neither_conditions_are_met : when_checking_if_one_of_two_conditions_are_met
        {
            It should_return_false = () => result.should_be_false();

            Because b = () =>
            {
                result = sut.is_satisfied_by(1);
            };

            static bool result;
        }
    }
}