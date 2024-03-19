using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RecordPlayerTime : MonoBehaviour
{
    [Header("Players Finish Time")]
    private TMP_Text currentTime;
    public string finishTimeP1Text;
    public string finishTimeP2Text;
    public float finishP1Time;
    public float finishP2Time;


    public bool p1End;
    public bool p2End;

    private TimeCounting timeCounting;




    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        

    }
    void Start()
    {
        currentTime = GameObject.FindGameObjectWithTag("Time").GetComponent<TMP_Text>();
        timeCounting = GameObject.FindGameObjectWithTag("TimeCounting").GetComponent<TimeCounting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            //CheckGameEnd();

            if (p1End)
            {
                p1End = false;
                finishTimeP1Text = currentTime.text;
                finishP1Time = timeCounting.elapsedTime;
                Debug.Log(timeCounting.elapsedTime);
            }

            if (p2End)
            {
                p2End = false;
                finishTimeP2Text = currentTime.text;
                finishP2Time = timeCounting.elapsedTime;
            }
        }
        
        
    }

    void CheckGameEnd()
    {
        if(finishTimeP1Text != "" && finishTimeP2Text != "")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player1"))
        {
            p1End = true;
        }
        if (other.CompareTag("player2"))
        {
            p2End = true;
        }
    }
}
