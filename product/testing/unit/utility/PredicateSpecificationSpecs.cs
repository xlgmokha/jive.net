using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Machine.Specifications;

namespace gorilla.commons.testing.unit.utility
{
    public class PredicateSpecificationSpecs
    {
        [Concern(typeof (PredicateSpecification<>))]
        public class when_checking_if_a_criteria_is_met_and_it_is
        {
            It should_return_true = () => new PredicateSpecification<int>(x => true).is_satisfied_by(1).should_be_true();
        }

        [Concern(typeof (PredicateSpecification<>))]
        public class when_checking_if_a_criteria_is_met_and_it_is_not
        {
            It should_return_true = () => new PredicateSpecification<int>(x => false).is_satisfied_by(1).should_be_false();
        }
    }
}