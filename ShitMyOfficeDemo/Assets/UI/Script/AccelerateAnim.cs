using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateAnim : MonoBehaviour
{
    private Animator accelerateAnim;
    void Start()
    {
        accelerateAnim = GetComponent<Animator>();
        StartCoroutine(StopForwardDemo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StopForwardDemo() 
    {
        yield return new WaitForSeconds(12f);
        accelerateAnim.SetTrigger("forwardEnd");
    }
}
