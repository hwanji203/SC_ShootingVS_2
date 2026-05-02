using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
    public void FaceDirection(Vector2 pointerPos)
    {
        transform.eulerAngles = pointerPos.x - transform.position.x > 0 ? Vector3.zero : new Vector3(0, 180f, 0);
    }
}
