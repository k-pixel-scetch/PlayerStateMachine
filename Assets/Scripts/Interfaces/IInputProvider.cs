using UnityEngine;

public interface IInputProvider
{
    Vector2 MovementInput { get; }
    bool HasMovementInput { get; }

    void Tick();
    void Enable();
    void Disable();
}