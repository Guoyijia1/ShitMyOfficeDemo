using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColiision : MonoBehaviour
{
    public float stepBackDistance = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is kinematic
        if (collision.gameObject.GetComponent<Rigidbody>() != null && collision.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            // Move the player back by the specified distance
            Vector3 stepBackVector = transform.forward * -stepBackDistance;
            transform.position += stepBackVector;
        }
    }
    /*
    public float stepBackDistance = 1f;
    public float stepBackDuration = 0.5f;

    private bool isSteppingBack = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isSteppingBack && collision.gameObject.GetComponent<Rigidbody>() != null && collision.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            StartCoroutine(StepBack());
        }
    }

    private IEnumerator StepBack()
    {
        isSteppingBack = true;

        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;
        Vector3 stepBackVector = transform.forward * -stepBackDistance;

        while (elapsedTime < stepBackDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, initialPosition + stepBackVector, elapsedTime / stepBackDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isSteppingBack = false;
    }
    */


    /*

    public float backwardForce = 500f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is kinematic
        if (collision.gameObject.GetComponent<Rigidbody>() != null && collision.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            // Calculate the backward force vector
            Vector3 backwardForceVector = -collision.contacts[0].normal * backwardForce;

            // Apply the force to the player's Rigidbody
            GetComponent<Rigidbody>().AddForce(backwardForceVector);
        }
    }
    */
}
