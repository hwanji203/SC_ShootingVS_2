using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AgentInput : MonoBehaviour
{
    public Vector2 MoveDIr { get; private set; }
    [field: SerializeField] public UnityEvent<Vector2> OnPointerChanged { get; private set; }

    public void OnMove(InputValue value)
    {
        MoveDIr = value.Get<Vector2>();
    }

    public void GetPointerInput()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        OnPointerChanged?.Invoke(mouseWorldPos);
    }

    private void Update()
    {
        GetPointerInput();
    }
}
