using UnityEngine;

public interface IMoveable
{
    void Move(Vector2 direction);
    void Stop();
    bool IsMoving { get; }
}
