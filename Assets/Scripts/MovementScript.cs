using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    //Acceleration Speed, Axis & Rigidbody
    private float acceleration = 8f;
    private Rigidbody2D charRB;
    private float horizontal, vertical;
    public Animator animator;

    private bool flipSpriteH = false;
    private bool flipSpriteV = false;

    private void Awake()
    {
        //Gets The Rigidbody From The Object
        charRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Gets The Local Input For Horizontal & Vertical Axis
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Sets The Float In Animator To The Current Horizontal & Vertical Speeds
        animator.SetFloat("horAccel", Mathf.Abs(horizontal));
        animator.SetFloat("vertAccel", Mathf.Abs(vertical));



        //Sprite Direction Logic
        if (horizontal < 0)
        {
            flipSpriteH = true;
        }
        if(vertical < 0)
        {
            flipSpriteV = true;
        }
        if(horizontal > 0)
        {
            flipSpriteH = false;
        }
        if(vertical > 0)
        {
            flipSpriteV = false;
        }


        //Sprite Is Flipped Based On Current Direction
        if(flipSpriteH && flipSpriteV)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(180f, 180f));
        }
        else if (flipSpriteV && !flipSpriteH)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(180f, 0f));
        }
        else if(!flipSpriteV && flipSpriteH)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f));
        }
        else if(!flipSpriteH && !flipSpriteV)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f));
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("attack");
        }
    }

    private void FixedUpdate()
    {
        charRB.velocity = new Vector2(horizontal * acceleration, vertical * acceleration);
        charRB.velocity.Normalize();
    }

}
