using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    private Rigidbody2D rb;
    public BulletDataSO BulletData { get; set; }

    public string ItemName => gameObject.name;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ResetItem()
    {

    }

    private IEnumerator waitForDeath()
    {
        yield return new WaitForSeconds(2);
        PoolManager.Instance.Push(this);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * BulletData.BulletSpeed;
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(waitForDeath());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PoolManager.Instance.Push(this);
    }
}
