using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMgr : MonoBehaviour
{

    [SerializeField]
    private Button backButton;

    private float countdown = 11f;

    void Update()
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            backButton.gameObject.SetActive(true);
        }

    }
}
