//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class ShootLayzer : MonoBehaviour
//{
//    [SerializeField] private float distance;
//    [SerializeField] private LayerMask mask;

//    private LineRenderer lineRenderer;

//    private void Awake()
//    {
//        lineRenderer = GetComponent<LineRenderer>();
//    }

//    private void Update()
//    {
//        if (Keyboard.current.spaceKey.wasPressedThisFrame)
//        {
//            Shoot();
//        }
//        if (Keyboard.current.cKey.wasPressedThisFrame)
//        {
//            Test();
//        }
//    }

//    private void Shoot()
//    {
//        Vector2 originePos = transform.position;
//        Vector2 dir = transform.right;
//        float dis = distance;
//        int count = 0;
//        lineRenderer.SetPosition(count, originePos);
//            //첫지점은 플레이어
//            //첫 dir은 right

        
//        do
//        {
//            //레이를 쏘기
//            RaycastHit2D hit = Physics2D.Raycast(originePos, dir, dis, mask);
//            //맞은 물체가 있는지 없는지 bool로 구하기
//            bool isHit = hit.collider != null;
//            //dis를 구하기 (flase면 남은 dis로)
//            dis = isHit ? hit.distance : dis;
//            //라인 그리기 dir * dis가 끝 지점
//            lineRenderer.positionCount = count + 2;
//            lineRenderer.SetPosition(count + 1. )
//            count++;
//            //남은 dis를 구하기 (남은 dis - dis)
//            //dir를 구하기
//        }
//        while (true);
//    }

//    private void Test()
//    {
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10, mask);

//        Debug.Log(hit);
//        Debug.Log(hit.distance);
//        Debug.Log(hit.point);
//        Debug.Log(hit.normal);
//        Debug.Log(hit.centroid);
//    }
//}
