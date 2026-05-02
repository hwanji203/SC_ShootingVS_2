using UnityEngine;

[CreateAssetMenu(fileName = "BulletDataSO", menuName = "Scriptable Objects/BulletDataSO")]
public class BulletDataSO : ScriptableObject
{
    [field:SerializeField]  
    public GameObject BulletPrefab { get; set; }
    [field:SerializeField]
    public float BulletSpeed { get; set; } = 1;
    [field:SerializeField]
    public int Damage { get; set; } 
}
