public interface IStateMachine
{
    void TransitionTo(IState newState);
    void FixedTick();
    void Tick();
    IState CurrentState { get; }
}
