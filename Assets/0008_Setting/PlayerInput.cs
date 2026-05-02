using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controlls;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "SO/PlayerInput")]
public class PlayerInput : ScriptableObject, IPlayerActions 
{
    private Controlls controlls;
    public Vector2 MoveDir { get; private set; }

    public event Action<Vector2> OnMousePosChange;
    public event Action<bool> OnIsShootingChange;

    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveDir = context.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        OnMousePosChange?.Invoke(mousePos);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnIsShootingChange?.Invoke(true);
        }
        if (context.canceled)
        {
            OnIsShootingChange?.Invoke(false);
        }
    }

    private void OnEnable()
    {
        if (controlls == null)
        {
            controlls = new();
        }

        controlls.Player.SetCallbacks(this);
        controlls.Player.Enable();
    }

    private void OnDisable()
    {
        controlls.Player.Disable();
    }
}
