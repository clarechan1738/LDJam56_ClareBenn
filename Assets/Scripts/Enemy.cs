using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    private float enemyMoveSpeed = 5.0f;

    private float distance;

    private bool cooldown = false;

    private float bufferTimer = 1.0f;

    private MovementScript mScript;
    public AudioClip playerHurt;

    private void Awake()
    {
        mScript = FindAnyObjectByType<MovementScript>();
    }

    void Update()
    {
        //Flips Enemy Sprite Rotation Based On Direction Player Is In (WIP)
        if(player.transform.position.x < transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(180f, 0f));
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f));
        }
        if(player.transform.position.y < transform.position.y)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f));
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f));
        }

        //Checks The Distance Between Enemy & Player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //Moves The Enemy To The Player Location
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);


        //If The Buffer Is Not On Cooldown Reset The Timer
        if(!cooldown)
        {
            bufferTimer = 1.0f;
        }
        //Otherwise, Count It Down
        else if(cooldown && bufferTimer > 0)
        {
            bufferTimer -= Time.deltaTime;
            if(bufferTimer == 0)
            {
                cooldown = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //If No Cooldown, Subtract Health On Collision With Player
            if(!cooldown)
            {
                mScript.source.PlayOneShot(playerHurt);
                GameManager.instance.playerHealth -= 5;
                GameManager.instance.healthBar.SetHealth(GameManager.instance.playerHealth);
                cooldown = true;
            }
           
        }
        else if(collision.gameObject.tag == "LargeEnemy")
        {
            mScript.source.PlayOneShot(playerHurt);
            GameManager.instance.playerHealth -= 10;
            GameManager.instance.healthBar.SetHealth(GameManager.instance.playerHealth);
            cooldown = true;
        }
        //Ends Game If Player Health Is 0
        else if (GameManager.instance.playerHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

}
