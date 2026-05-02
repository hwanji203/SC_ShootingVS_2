using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool value)
    {
        int flip = value ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, flip * Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

    public void OrderLayer(float rotateValue)
    {
        spriteRenderer.sortingOrder = rotateValue > 0 && rotateValue < 180 ? -1 : 1;
    }
}
