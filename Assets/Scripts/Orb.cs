using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private float orbSpeed = 9.0f;
    private Rigidbody2D rb;

    private float lifespan = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * orbSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (lifespan > 0)
        {
            lifespan -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            lifespan = 2.0f;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }
}
