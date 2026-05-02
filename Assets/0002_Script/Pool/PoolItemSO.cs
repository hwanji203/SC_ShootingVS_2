using UnityEngine;

[CreateAssetMenu(fileName = "PoolItemSO", menuName = "Scriptable Objects/PoolItemSO")]
public class PoolItemSO : ScriptableObject
{
    [field: SerializeField] public string PoolName;
    public GameObject prefab;
    public int count;

    private void OnValidate()
    {
        if (prefab != null)
        {
            if (prefab.TryGetComponent<IPoolable>(out var poolable))
            {
                PoolName = poolable.ItemName;
            }
            else
            {
                prefab = null;
                Debug.Log("can't find poolable instance");
            }
        }
    }
}
