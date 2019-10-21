using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
    public class NotSpecificationSpecs
    {
        [Subject(typeof (NotSpecification<>))]
        public class when_checking_if_a_condition_is_not_met
        {
            static protected Moq.Mock<Specification<int>> criteria;

            Establish c = () =>
            {
                criteria = Create.An<Specification<int>>();
                sut = create_sut();
            };

            static protected Specification<int> sut;

            static Specification<int> create_sut()
            {
                return new NotSpecification<int>(criteria.Object);
            }
        }

        [Subject(typeof (NotSpecification<>))]
        public class when_a_condition_is_not_met : when_checking_if_a_condition_is_not_met
        {
            Establish c = () => criteria.Setup(x => x.is_satisfied_by(1)).Returns(false);

            Because b = () =>
            {
                result = sut.is_satisfied_by(1);
            };

            It should_return_true = () => result.should_be_true();

            static bool result;
        }

        [Subject(typeof (NotSpecification<>))]
        public class when_a_condition_is_met : when_checking_if_a_condition_is_not_met
        {
            Establish c = () => criteria.Setup(x => x.is_satisfied_by(1)).Returns(true);

            Because b = () =>
            {
                result = sut.is_satisfied_by(1);
            };

            It should_return_false = () => result.should_be_false();

            static bool result;
        }
    }
}
