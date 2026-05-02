using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float effectTime = 0.2f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private LayerMask whatIsLayer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    public void TryShooting(GameObject target)
    {
        Vector2 dir = target.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, attackRange, whatIsLayer);

        if (hit.collider != null)
        {
            StartCoroutine(EffectCoroutine(hit.point));
        }
        else
        {
            StartCoroutine(EffectCoroutine(transform.position + (Vector3)dir.normalized * attackRange));
        }

    }

    private IEnumerator EffectCoroutine(Vector2 pos)
    {
        lineRenderer.SetPosition(0, transform.position);                //시작 위치
        lineRenderer.SetPosition(1, pos);         //끝 위치
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(effectTime);

        lineRenderer.enabled = false;
    }
}
