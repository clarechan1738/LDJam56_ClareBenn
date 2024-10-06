using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        //Follows Player's Position
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
