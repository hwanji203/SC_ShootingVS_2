using System.Collections;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private WeaponDataSO weaponData;
    [SerializeField] private BulletDataSO bulletData;

    [SerializeField] private Transform firePos;

    [SerializeField] private int ammo = 100;

    private bool isShooting = false;
    private bool isCoolTime = false;

    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);
        }
    }

    private void Start()
    {
        ammo = weaponData.AmmoCapacity;
    }

    private void Update()
    {
        UseWeapon();
    }

    public void TryShooting()
    {
        isShooting = true;
    }
    public void TryStopShooting()
    {
        isShooting = false;
    }

    public void Reload(int ammoCount)
    {
        Ammo += ammoCount;
    }

    private void UseWeapon()
    {
        if (isShooting == true && isCoolTime == false)
        {
            if(Ammo > 0)
            {
                Ammo--;

                for (int i = 0; i < weaponData.GetBulletCount(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                return;
            }
            FinishShooting();
        }
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayShootCoroutine());
        if (weaponData.AutomaticFire == false)
        {
            isShooting = false;
        }
    }

    private IEnumerator DelayShootCoroutine()
    {
        isCoolTime = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        Reload(weaponData.AmmoCapacity);
        isCoolTime = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(firePos.position);
    }

    private void SpawnBullet(Vector3 position)
    {
        GameObject Bullet = PoolManager.Instance.Pop("Bullet").GetGameObject();
        Bullet.transform.position = position;
        Bullet.transform.rotation = transform.rotation * CalculateAngle();
        Bullet.GetComponent<Bullet>().BulletData = bulletData;
    }

    private Quaternion CalculateAngle()
    {
        float spreadAngle = 0;

        if (weaponData.MultiFire)
        {
            spreadAngle = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        }

        return Quaternion.Euler(new Vector3(0, 0, spreadAngle));
    }
}
