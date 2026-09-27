public class StateMachine: IStateMachine
{
    private IState _currentState;
    public IState CurrentState => _currentState;

    public void TransitionTo(IState newState) 
    {
        _currentState?.Exit();

        _currentState = newState;

        _currentState?.Enter();
    }

    public void FixedTick() 
    {
        if (_currentState is IFixedTickableState fixedTickable) 
        { 
            fixedTickable.FixedTick();
        }
    }

    public void Tick() 
    {
        if (_currentState is ITickableState tickable)
        {
            tickable.Tick();
        }
    }
}
