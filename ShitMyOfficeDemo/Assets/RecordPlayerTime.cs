using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordPlayerTime : MonoBehaviour
{
    [Header("Players Finish Time")]
    [SerializeField] TextMeshProUGUI currentTime;
    public string finishTimeP1;
    public string finishTimeP2;

    public bool p1End;
    public bool p2End;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameEnd();

        if (p1End)
        {
            p1End = false;
            finishTimeP1 = currentTime.text;
        }

        if (p2End)
        {
            p2End = false;
            finishTimeP2 = currentTime.text;
        }
    }

    void CheckGameEnd()
    {
        if(finishTimeP1 != "" && finishTimeP2 != "")
        {
            Debug.Log("Game Over");
        }
    }
}
