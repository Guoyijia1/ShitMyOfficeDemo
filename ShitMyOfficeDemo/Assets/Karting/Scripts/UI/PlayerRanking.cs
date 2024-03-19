using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRanking : MonoBehaviour
{
    [SerializeField] private List<Sprite> playerRank = new List<Sprite>();
    public int playerRankNum;

    private Image rankImage;
    private Animator rankAnim;

    private bool hasInitRank;

    void Start()
    {
        rankImage = GetComponent<Image>();
        rankImage.sprite = null;
        rankAnim = GetComponent<Animator>();
        rankAnim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasInitRank)
        {
            StartCoroutine(InitPlayerRank());
        }
        
    }

    IEnumerator InitPlayerRank()
    {
        hasInitRank = true;
        yield return new WaitForSeconds(1f);
        rankImage.sprite = playerRank[playerRankNum];
        rankAnim.enabled = true;
    }
}
