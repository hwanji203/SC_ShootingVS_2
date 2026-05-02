using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [field: SerializeField] private AgentMovementSO MoveData { get; set; }
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _currentVelocity = 3f;
    private Vector2 MoveDir;

    public event Action<float> OnVelocityChanged;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetMove(Vector2 moveDir)
    {
        MoveDir = moveDir;
        _currentVelocity = CalculateSpeed(moveDir);
    }

    private float CalculateSpeed(Vector2 value)
    {
        if (value.sqrMagnitude > 0)
        {
            _currentVelocity += MoveData.acceleration * Time.deltaTime;
        }
        else
        {
            _currentVelocity -= MoveData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(_currentVelocity, 0, MoveData.maxSpeed);
    }

    public void StopMove()
    {
        _currentVelocity = 0;
    }

    private void Move()
    {
        _rigidbody2D.linearVelocity = MoveDir * _currentVelocity;
    }

    private void FixedUpdate()
    {
        OnVelocityChanged?.Invoke(_currentVelocity);
        Move();
    }
}