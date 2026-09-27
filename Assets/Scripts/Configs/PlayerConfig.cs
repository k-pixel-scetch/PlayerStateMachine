using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player Config")]
public class PlayerConfig : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float _playerSpeed = 5f;
    public float PlayerSpeed => this._playerSpeed;
}
