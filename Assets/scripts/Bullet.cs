using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 5.0f;

    private Rigidbody2D rb;
    private float dx = 0, dy = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void OnEnable()
    {
        Debug.Log("FLY!");
        rb.velocity = transform.up * Speed;
    }
}
