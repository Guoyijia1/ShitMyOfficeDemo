using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onboarding : MonoBehaviour
{
    private Animator playerAnim;

    [Header("Tag")]
    [SerializeField] string currentTag;

    
    public bool player1Seated;
    public bool player2Seated;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PlayerSeated());

        
        

    }

    IEnumerator PlayerSeated()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && CompareTag("player1"))
        {
            playerAnim.SetBool("playerSeated", true);
            player1Seated = true;
            yield return null;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && CompareTag("player2"))
        {
            playerAnim.SetBool("playerSeated", true);
            player2Seated = true;
            yield return null;
           
        }
    }

    
}
