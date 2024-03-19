using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopRegenerate : MonoBehaviour
{
    public GameObject childOne;
    public GameObject childTwo;

    void Start()
    {
        // Ensure childOne is active and childTwo is inactive at the beginning
        childOne.SetActive(true);
        childTwo.SetActive(false);
    }

    void Update()
    {
        // Check if childOne is destroyed
        if (childOne == null)
        {
            // Start a coroutine to wait for 3 seconds before activating childTwo
            StartCoroutine(ActivateChildTwoAfterDelay(3f));

            // Disable this script to avoid unnecessary updates
            enabled = false;
        }
    }

    IEnumerator ActivateChildTwoAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Activate childTwo
        childTwo.SetActive(true);
    }
}
