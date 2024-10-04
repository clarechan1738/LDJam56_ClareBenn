using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private float acceleration = 10f;
    private Rigidbody2D charRB;
    private float horizontal, vertical;

    private void Awake()
    {
        charRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        charRB.velocity = new Vector2(horizontal * acceleration, vertical * acceleration);
    }

}
