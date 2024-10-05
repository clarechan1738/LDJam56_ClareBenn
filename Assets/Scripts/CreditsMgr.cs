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
        totalScore = sScript.GetScore().ToString();
        scoreTxt.text = totalScore + "0000";
        Destroy(sScript.gameObject);
    }

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
