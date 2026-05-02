using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    public Animator AnimCompo { get; private set; }
    private readonly int isWalkHash = Animator.StringToHash("IsMove");

    private void Awake()
    {
        AnimCompo = GetComponent<Animator>();
    }

    public void SetWalkAnimation(bool value)
    {
        AnimCompo.SetBool(isWalkHash, value);
    }

    public void AnimatePlayer(float velocity)
    {
        if (velocity > 0)
        {
            SetWalkAnimation(true);
        }
        else
        {
            SetWalkAnimation(false);
        }
    }
}
