using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDebug : MonoBehaviour
{
    [Header("Card Info Update")]
    [SerializeField] private string playerTimeText;
    public int playerNum;
    [SerializeField] private float playerTime;

    [Header("Card")]
    [SerializeField] private float defaultTime;
    [SerializeField] private List<float> titleOffset = new List<float>();
    [SerializeField] private List<Sprite> cardImg = new List<Sprite>();
    [SerializeField] private List<string> jobTitles = new List<string>();

    private TMP_Text jobTimeText;
    private TMP_Text jobTitleText;

    private Animator jobTimeAnim;
    private Animator jobTitleAnim;

    private Animator cardAnim;

    private bool hasInfoUpdated;

    private RecordPlayerTime RecordPlayerTime;
    void Start()
    {
        GetComponent<Image>().sprite = cardImg[playerNum];

        RecordPlayerTime = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RecordPlayerTime>();

        jobTimeAnim = transform.GetChild(0).transform.GetComponent<Animator>();
        jobTitleAnim = transform.GetChild(1).transform.GetComponent<Animator>();

        jobTimeText = transform.GetChild(0).transform.GetComponent<TMP_Text>();
        jobTitleText = transform.GetChild(1).transform.GetComponent<TMP_Text>();

        cardAnim = GetComponent<Animator>();
        cardAnim.enabled = false;
        jobTimeAnim.enabled = false;
        jobTitleAnim.enabled = false;
        hasInfoUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasInfoUpdated)
        {
            StartCoroutine(CardInfoUpdate());
        }
    }

    IEnumerator CardInfoUpdate()
    {
        hasInfoUpdated = true;

        yield return new WaitForSeconds(1f);
        cardAnim.enabled = true;

        yield return new WaitForSeconds(1f);
        UpdatePlayerTime();
        jobTimeAnim.enabled = true;

        yield return new WaitForSeconds(1f);
        UpdatePlayerTitle();
        jobTitleAnim.enabled = true;
    }

    void UpdatePlayerTime()
    {
        if(playerNum == 0)
        {
            playerTime = RecordPlayerTime.finishP1Time;
            jobTimeText.text = RecordPlayerTime.finishTimeP1Text;
        }
        if (playerNum == 1)
        {
            playerTime = RecordPlayerTime.finishP2Time;
            jobTimeText.text = RecordPlayerTime.finishTimeP2Text;
        }

    }

    void UpdatePlayerTitle()
    {
        AssignTitle();
    }

    void AssignTitle()
    {
        if (playerTime <= defaultTime)
        {
            jobTitleText.text = jobTitles[4];
        }
        else if (playerTime > defaultTime && playerTime <= defaultTime * titleOffset[2])
        {
            jobTitleText.text = jobTitles[3];
        }
        else if (playerTime > defaultTime * titleOffset[2] && playerTime <= defaultTime * titleOffset[1])
        {
            jobTitleText.text = jobTitles[2];
        }
        else if (playerTime > defaultTime * titleOffset[1] && playerTime <= defaultTime * titleOffset[0])
        {
            jobTitleText.text = jobTitles[1];
        }
        else
        {
            jobTitleText.text = jobTitles[0];
        }
    }
}
