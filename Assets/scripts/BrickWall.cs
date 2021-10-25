using UnityEngine;

public class BrickWall : MonoBehaviour, IDamageable {

    public SpriteMask mask;
    private BoxCollider2D col;
    private float damagePercent = 0.25f;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    public void ApplyDamage(float points, Vector2 direction)
    {
        var sizeChange = new Vector2(Mathf.Abs(direction.x), Mathf.Abs(direction.y)) * damagePercent;
        var offsetChange = direction * (damagePercent / 2);

        col.size -= sizeChange;
        col.offset += offsetChange;

        mask.transform.localScale -= new Vector3(sizeChange.x, sizeChange.y, 0);
        mask.transform.position += new Vector3(offsetChange.x, offsetChange.y, 0);

        if (col.size.x * col.size.y <= 0.01)
            gameObject.SetActive(false);
    }
}
