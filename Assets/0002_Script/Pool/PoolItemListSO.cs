using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolItemListSO", menuName = "Scriptable Objects/PoolItemListSO")]
public class PoolItemListSO : ScriptableObject
{
    public List<PoolItemSO> list;
}
