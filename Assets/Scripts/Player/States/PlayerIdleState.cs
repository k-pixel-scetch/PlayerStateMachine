using UnityEngine;

public class PlayerIdleState: ITickableState
{
    private readonly IStateMachine _stateMachine;
    private readonly IStateFactory _stateFactory;
    private readonly IInputProvider _inputProvider;

    public PlayerIdleState(IInputProvider inputProvider, IStateMachine stateMachine, IStateFactory stateFactory)
    {
        _stateMachine = stateMachine;

        _stateFactory = stateFactory;

        _inputProvider = inputProvider;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle State.");
    }

    public void Tick()
    {
        if (_inputProvider.HasMovementInput) 
        {
            _stateMachine.TransitionTo(_stateFactory.CreateState(PlayerStateType.Walk));
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Idle State.");
    }
}
