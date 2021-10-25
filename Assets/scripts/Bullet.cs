using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 5.0f;
    public float Damage = 1.0f;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.up * Speed;
        direction = rb.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObj = collision.gameObject.GetComponent<IDamageable>();
        if (collisionObj != null)
            collisionObj.ApplyDamage(Damage, direction);
        gameObject.SetActive(false);
    }
}
