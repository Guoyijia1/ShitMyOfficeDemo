using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JobCard : MonoBehaviour
{
    [Header("Card Info Update")]
    [SerializeField] private string playerTimeText;
    [SerializeField] private int playerNum;
    public float playerTime;

    [Header("Card")]
    [SerializeField] private float defaultTime;
    [SerializeField] private List<float> titleOffset = new List<float>();
    [SerializeField] private List<Sprite> cardImg = new List<Sprite>();
    [SerializeField] private List<string> jobTitles = new List<string>();

    private Animator jobTimeAnim;
    private Animator jobTitleAnim;

    private Animator cardAnim;

    private TextMeshPro jobTimeText;
    private TextMeshPro jobTitleText;

    private bool hasInfoUpdated;
    void Start()
    {
        GetComponent <Image>().sprite = cardImg[playerNum];


        jobTimeAnim = transform.GetChild(0).transform.GetComponent<Animator>();
        jobTitleAnim = transform.GetChild(1).transform.GetComponent<Animator>();

        jobTimeText = transform.GetChild(0).transform.GetComponent<TextMeshPro>();
        jobTitleText = transform.GetChild(1).transform.GetComponent<TextMeshPro>();

        cardAnim = GetComponent<Animator>();
        cardAnim.enabled = false;
        jobTimeAnim.enabled = false;
        jobTimeAnim.enabled = false;
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

    }

    void UpdatePlayerTitle()
    {
        AssignTitle();
    } 

    void AssignTitle()
    {
        if(playerTime <= defaultTime)
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
        }else
        {
            jobTitleText.text = jobTitles[0];
        }
    }
}
