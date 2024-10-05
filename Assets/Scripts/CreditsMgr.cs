using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMgr : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoreTxt;

    [SerializeField]
    private Button backButton;

    private float countdown = 11f;

    public string totalScore;

    public ScoreScript sScript;


    private void Awake()
    {
        sScript = FindAnyObjectByType<ScoreScript>();

        //Converts The Score To A String & Displays It With Added Zeroes For Appearance
        totalScore = sScript.GetScore().ToString();
        scoreTxt.text = totalScore + "0000";

        //Deletes Itself After Information Is Brought In
        Destroy(sScript.gameObject);
    }

    void Update()
    {
        //Counts Down For The Back Button To Display
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
