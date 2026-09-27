using System;
using Zenject;

public class StateFactory: IStateFactory
{
    private readonly DiContainer _container;
    private readonly IStateMachine _stateMachine;
    private readonly IInputProvider _inputProvider;
    private readonly IMoveable _moveable;

    public StateFactory(DiContainer container, IStateMachine stateMachine, IInputProvider inputProvider, IMoveable moveable) 
    { 
        _container = container;

        _stateMachine = stateMachine;

        _inputProvider = inputProvider;

        _moveable = moveable;
    }

    public IState CreateState(PlayerStateType type) 
    { 
        return type switch 
        { 
            PlayerStateType.Idle => _container.Instantiate<PlayerIdleState>( new object[] { _inputProvider, _stateMachine, this }),

            PlayerStateType.Walk => _container.Instantiate<PlayerWalkState>( new object[] { _inputProvider, _stateMachine, this, _moveable }),

            _ => throw new ArgumentException($"Unknown state type: {type}")
        };
    }
}
