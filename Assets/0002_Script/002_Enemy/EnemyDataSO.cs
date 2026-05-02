using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Scriptable Objects/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField] public float AttackRange { get; set; }
    [field: SerializeField] public float ChaseRange { get; set; }

    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public float Cooltime { get; set; }
}
