using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyDataSO EnemyData { get; set; }
    public AgentMovement MoveComp { get; private set; }
    public AgentRenderer RenderCompo { get; private set; }

    private void Awake()
    {
        MoveComp = GetComponent<AgentMovement>();
        RenderCompo = GetComponent<AgentRenderer>();
    }


}
