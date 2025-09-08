using UnityEngine;

public class Player : MonoBehaviour
{
    public AgentInput InputCompo { get; private set; }  
    public AgentMovement MoveCompo { get; private set; }

    private void Awake()
    {
        InputCompo = GetComponent<AgentInput>();
        MoveCompo = GetComponent<AgentMovement>();
    }

    private void Update()
    {
        MoveCompo.SetMove(InputCompo.MoveDIr);
    }
}
