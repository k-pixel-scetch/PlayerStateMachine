using UnityEngine;

public class PlayerWalkState: ITickableState, IFixedTickableState
{
    private readonly IStateMachine _stateMachine;
    private readonly IStateFactory _stateFactory;
    private readonly IInputProvider _inputProvider;
    private readonly IMoveable _moveable;

    public PlayerWalkState(IInputProvider inputProvider, IStateMachine stateMachine, IStateFactory stateFactory, IMoveable moveable) 
    { 
        _stateMachine = stateMachine;

        _stateFactory = stateFactory;

        _inputProvider = inputProvider;

        _moveable = moveable;
    }

    public void Enter() 
    {
        Debug.Log("Enter Walk State.");
    }

    public void FixedTick()
    {
        if (_inputProvider.HasMovementInput) 
        {
            _moveable.Move(_inputProvider.MovementInput);
        }
        else 
        {
            _moveable.Stop();
        }
    }

    public void Tick() 
    { 
        if (!_inputProvider.HasMovementInput) 
        {
            _moveable.Stop();

            _stateMachine.TransitionTo(_stateFactory.CreateState(PlayerStateType.Idle));
        }
    }

    public void Exit() 
    {
        Debug.Log("Exit Walk State");
    }
}
