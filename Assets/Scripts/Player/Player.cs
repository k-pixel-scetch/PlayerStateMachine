using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] private IStateMachine _stateMachine;
    [Inject] private IStateFactory _stateFactory;
    [Inject] private IInputProvider _inputProvider;

    private void Start()
    {
        _inputProvider.Enable();

        _stateMachine.TransitionTo(_stateFactory.CreateState(PlayerStateType.Idle));
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedTick();
    }

    private void Update()
    {
        _inputProvider.Tick();
        _stateMachine.Tick();
    }

    private void OnDestroy()
    {
        _inputProvider.Disable();
    }
}
