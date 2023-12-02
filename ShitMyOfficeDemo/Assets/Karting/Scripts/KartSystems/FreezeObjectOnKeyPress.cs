using UnityEngine;
using System.Collections;

public class FreezeObjectOnKeyPress : MonoBehaviour
{
    public Transform movingObject; // Assign your moving object in the Inspector
    public float freezeDistance = 10f; // Distance threshold to freeze the object
    public KeyCode freezeKey = KeyCode.B;
    public float freezeDuration = 2f; // Duration to freeze the object in seconds

    private bool isFrozen = false;

    void Update()
    {
        // Check the distance between player and moving object
        float distance = Vector3.Distance(transform.position, movingObject.position);

        // Check if the distance is less than the threshold and the freeze key is pressed
        if (distance < freezeDistance && Input.GetKeyDown(freezeKey))
        {
            // Toggle freeze state
            isFrozen = !isFrozen;

            // Start the coroutine to freeze the object for the specified duration
            if (isFrozen)
            {
                StartCoroutine(FreezeObjectForDuration());
            }
        }
    }

    IEnumerator FreezeObjectForDuration()
    {
        // Freeze the object
        Rigidbody movingObjectRb = movingObject.GetComponent<Rigidbody>();
        if (movingObjectRb != null)
        {
            movingObjectRb.isKinematic = true;
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(freezeDuration);

        // Unfreeze the object
        if (movingObjectRb != null)
        {
            movingObjectRb.isKinematic = false;
        }
    }
}
