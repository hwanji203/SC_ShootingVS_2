using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float currentVelocity = 3f;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetMove(Vector2 value)
    {
        moveDir = value;
        //currentVelocity = CalculateSpeed(value);
    }

    private void CalculateSpeed(Vector2 value)
    {
        throw new NotImplementedException();
    }

    private void Move()
    {
        rb.linearVelocity = moveDir * currentVelocity;
    }
}
