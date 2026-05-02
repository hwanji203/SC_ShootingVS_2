using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class EnemySignal : MonoBehaviour
{
    public void ReceiveSignal()
    {
        Debug.Log("현우는 바보");
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GetComponent<PlayableDirector>().Play();
        }
    }
}
