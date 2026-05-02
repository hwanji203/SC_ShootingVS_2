using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerInput InputCompo { get; private set; }  
    public AgentMovement MoveCompo { get; private set; }
    public PlayerWeapon WeaponCompo { get; private set; }
    public AgentRenderer AgentRenderer { get; private set; }

    private event Action OnFireBtnReleased;
    private event Action OnFireBtnPressed;

    private void Awake()
    {
        MoveCompo = GetComponent<AgentMovement>();
        WeaponCompo = GetComponentInChildren<PlayerWeapon>();
        AgentRenderer = GetComponentInChildren<AgentRenderer>();
    }

    private void Start()
    {
        InputCompo.OnMousePosChange += WeaponCompo.AimWeapon;
        InputCompo.OnMousePosChange += AgentRenderer.FaceDirection;

        OnFireBtnPressed += WeaponCompo.StartFire;
        OnFireBtnReleased += WeaponCompo.EndFire;

        InputCompo.OnIsShootingChange += (press) =>
        {
            if (press == true) OnFireBtnPressed?.Invoke();
            else OnFireBtnReleased?.Invoke();
        };
    }

    private void Update()
    {
        MoveCompo.SetMove(InputCompo.MoveDir);
    }
}
