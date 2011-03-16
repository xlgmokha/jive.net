namespace gorilla.commons.utility
{
    public interface SubjectOf<in State> where State : utility.State
    {
        void change_state_to(State new_state);
    }
}