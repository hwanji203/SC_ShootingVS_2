using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, Pool> poolDictionary = new();
    [SerializeField] private PoolItemListSO poolList; 

    public static PoolManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (PoolItemSO item in poolList.list)
        {
            CreatePool(item.prefab, item.count);
        }
    }

    private void CreatePool(GameObject prefab, int count)
    {
        IPoolable poolable = prefab.GetComponent<IPoolable>();
        Pool pool = new Pool(poolable, transform, count);

        poolDictionary.Add(poolable.ItemName, pool);
    }

    public IPoolable Pop(string itemName)
    {
        if (poolDictionary.ContainsKey(itemName))
        {
            return poolDictionary[itemName].Pop();
        }
        else
        {
            Debug.Log("There is no pool");
            return null;
        }
    }

    public void Push(IPoolable poolable)
    {
        if (poolDictionary.ContainsKey(poolable.ItemName))
        {
            poolDictionary[poolable.ItemName].Push(poolable);
        }
        else
        {
            Debug.Log("There is no pool");
        }
    }
}
