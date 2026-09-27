using UnityEngine;
using Zenject;

public class PlayerInputProvider: IInputProvider
{
    private readonly GameInput _gameInput;
    private Vector2 _movementInput;

    public Vector2 MovementInput => _movementInput;
    public bool HasMovementInput => _movementInput.sqrMagnitude > 0.0001f;

    [Inject]
    public PlayerInputProvider(GameInput gameInput) 
    { 
        _gameInput = gameInput;
    }

    public void Tick() 
    {
        _movementInput = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
    }

    public void Enable() 
    {
        _gameInput.Enable();
    }

    public void Disable()
    {
        _gameInput.Disable();
    }
}
