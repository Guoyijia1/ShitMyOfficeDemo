
using UnityEngine;

public class AddForceOnKeyPress : MonoBehaviour
{

    public float forceMagnitude = 10f; // Adjust the force strength as needed
    public KeyCode keyToPress = KeyCode.M;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure there is a Rigidbody component attached to the GameObject
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject.");
            enabled = false; // Disable the script
        }
    }

    private void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(keyToPress))
        {
            // Apply force in the forward direction of the GameObject
            rb.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
        }
    }
}
