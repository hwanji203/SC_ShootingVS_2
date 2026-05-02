using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "SO/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    [field:Range(0, 100)]
    public int AmmoCapacity { get; set; } = 100;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = 0.1f;

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    public bool MultiFire { get; set; } = false;

    [SerializeField]
    [Range(1, 15)]
    private int bulletCount = 0;

    [field: SerializeField]
    [Range(0, 10)]
    public float SpreadAngle { get; set; } = 5f;
    public int GetBulletCount()
    {
        if (MultiFire)
        {
            return bulletCount;
        }
        return 1;
    }
}
