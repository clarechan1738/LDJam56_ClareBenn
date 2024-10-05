using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    private float enemyMoveSpeed = 6.0f;

    private float distance;

    private bool cooldown = false;

    private float bufferTimer = 1.0f;

    void Update()
    {
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

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);

        if(!cooldown)
        {
            bufferTimer = 1.0f;
        }
        else if(cooldown && bufferTimer > 0)
        {
            bufferTimer -= Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!cooldown)
            {
                GameManager.instance.playerHealth -= 1;
                GameManager.instance.healthBar.SetHealth(GameManager.instance.playerHealth);
                cooldown = true;
            }
            else
            {
                //Wait For Time To Run Down
                
            }
           
        }
        else if (GameManager.instance.playerHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

}
