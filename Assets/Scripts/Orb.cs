using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Orb : MonoBehaviour
{
    private float orbSpeed = 9.0f;
    private Rigidbody2D rb;

    private float lifespan = 2.0f;

    public ScoreScript sScript;
    private void Awake()
    {
        sScript = GetComponent<ScoreScript>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Moves The Orbs In The Direction The Player Is Facing
        rb.AddForce(transform.right * orbSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        //Destroys Itself After 2 Seconds Of No Collisions
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
            //Destroys A Bullet Upon Hitting An Enemy & Adds 1 To The Score Count
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManager.instance.score++;
        }

    }
}
