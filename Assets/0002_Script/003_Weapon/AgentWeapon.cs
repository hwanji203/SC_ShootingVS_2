using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected float desireAngle;
    protected WeaponRenderer weaponRenderer;
    private Rifle rifle;

    private void Awake()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        rifle = GetComponentInChildren<Rifle>();
    }

    public virtual void AimWeapon(Vector2 pointerPos)
    {
        Vector2 dir = pointerPos - (Vector2)transform.position;
        desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.Euler(0, 0, desireAngle);
    }

    public virtual void StartFire()
    {
        rifle.TryShooting();
    }
    public virtual void EndFire()
    {
        rifle.TryStopShooting();
    }

    protected void AdjustWeaponRendering()
    {
        weaponRenderer.FlipSprite(desireAngle is > 90 or < -90);
        weaponRenderer.OrderLayer(desireAngle);
    }
}
