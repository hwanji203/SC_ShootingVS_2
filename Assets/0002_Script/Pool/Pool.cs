using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Stack<IPoolable> pool;
    private Transform parent;
    private IPoolable poolable;
    private GameObject prefab;

    public Pool(IPoolable poolable, Transform parent, int count)
    {
        this.poolable = poolable;
        prefab = poolable.GetGameObject();
        this.parent = parent;

        pool = new Stack<IPoolable>();

        for (int i = 0; i < count; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab, this.parent);
            obj.name = poolable.ItemName;
            obj.SetActive(false);
            pool.Push(obj.GetComponent<IPoolable>());
        }
    }

    public IPoolable Pop()
    {
        IPoolable item = null;

        if (pool.Count == 0)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            obj.name = poolable.ItemName;
            item = obj.GetComponent<IPoolable>();
        }
        else
        {
            item = pool.Pop();
            item.GetGameObject().SetActive(true);
        }

        return item;
    }

    public void Push(IPoolable poolable)
    {
        pool.Push(poolable);
        poolable.ResetItem();
        poolable.GetGameObject().SetActive(false);
    }
}
