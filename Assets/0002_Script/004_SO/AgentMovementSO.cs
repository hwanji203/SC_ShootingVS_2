using UnityEngine;

[CreateAssetMenu(fileName = "AgentMovementSO", menuName = "SO/AgentMovementSO")]
public class AgentMovementSO : ScriptableObject
{
    [Range(0, 100)]
    public float acceleration, deacceleration;

    [Range(0.1f, 10)]
    public float maxSpeed;
}
