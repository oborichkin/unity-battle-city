using UnityEngine;

public class Tank : MonoBehaviour {
    public float speed = 15.0f;
    public Transform firePosition;
    public GameObject bullet;

    private Rigidbody2D rb;
    private float dx = 0.0f, dy = 0.0f;
    private GameObject projectile;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        projectile = Instantiate(bullet);
        projectile.SetActive(false);
    }

	void Update ()
    {
        dx = Input.GetAxisRaw("Horizontal");
        dy = dx == 0.0f ? Input.GetAxisRaw("Vertical") : 0.0f;
        

        if (dx != 0)
        {
            if (dx == 1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        else if (dy != 0)
        {
            if (dy == 1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }

        rb.velocity = new Vector2(dx, dy) * speed;

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        projectile.SetActive(false);
        if (!projectile.activeInHierarchy)
        {
            projectile.transform.position = firePosition.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
        }
    }
}
