using UnityEngine;
using Zenject;

public class PlayerMovement : IMoveable
{
    private readonly Rigidbody2D _rigidbody2D;
    private readonly PlayerConfig _playerConfig;

    private bool _isMoving;
    public bool IsMoving => _isMoving;

    public float Speed => _playerConfig.PlayerSpeed;

    [Inject]
    public PlayerMovement(Player player, PlayerConfig playerConfig) 
    { 
        _rigidbody2D = player.GetComponent<Rigidbody2D>();

        _playerConfig = playerConfig;

        if (_rigidbody2D == null)
        {
            Debug.LogError("PlayerMovement: Rigidbody2D component is missing on Player!");
        }
    }

    public void Move(Vector2 direction) 
    { 
        if (direction.sqrMagnitude < 0.0001f) 
        {
            Stop();

            return;
        }

        _isMoving = true;

        _rigidbody2D.linearVelocity = direction * Speed;
    }

    public void Stop()
    {
        if (!_isMoving) return;

        _isMoving = false;

        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}
