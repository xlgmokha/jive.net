namespace gorilla.commons.utility
{
    public interface SubjectOf<State> where State : utility.State
    {
        void change_state_to(State new_state);
    }
}