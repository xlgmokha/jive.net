namespace jive
{
  public interface SubjectOf<in State> where State : jive.State
  {
    void change_state_to(State new_state);
  }
}
