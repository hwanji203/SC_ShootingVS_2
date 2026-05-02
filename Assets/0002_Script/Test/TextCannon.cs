using UnityEngine;
using UnityEngine.InputSystem;

public class TextCannon : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1;
    [SerializeField] private float moveSpeed = 10;

    private Vector3 mousePos;
    private Vector3 wasMyPos;
    private float timmer;
    private bool move;
    private float time;

    [SerializeField] private GameObject tri;
    private float triTimmer;
    [SerializeField] private float speed;

    private void Update()
    {
        if (move)
        {
            timmer += Time.deltaTime;
            Move();
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
            Vector2 dir = (mousePos - transform.position).normalized;
            float rad = Mathf.Atan2(dir.y, dir.x);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rad * Mathf.Rad2Deg));

            wasMyPos = transform.position;
            move = true;
            timmer = 0;
            time = (mousePos - wasMyPos).magnitude / moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime);
        }



        triTimmer += Time.deltaTime;
        tri.transform.position = transform.position + new Vector3(Mathf.Cos(triTimmer * Mathf.Rad2Deg * speed) * 2.5f, Mathf.Sin(triTimmer * Mathf.Rad2Deg * speed) * 2.5f);
    }

    private void Move()
    {
        float targetX = Mathf.Lerp(wasMyPos.x, mousePos.x, timmer / time);
        float targetY = Mathf.Lerp(wasMyPos.y, mousePos.y, timmer / time);

        transform.position = new Vector3(targetX, targetY);

        if (timmer / time >= 1)
        {
            timmer = 0;
            move = false;
        }
    }
}
