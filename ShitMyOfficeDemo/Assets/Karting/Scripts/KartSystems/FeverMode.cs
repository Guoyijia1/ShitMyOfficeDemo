using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    private ArcadeKart arcadeKart;

    void Start()
    {
        // Get the ArcadeKart component attached to the same GameObject
        arcadeKart = GetComponent<ArcadeKart>();

        if (arcadeKart != null)
        {
            // Modify the baseStats value as needed
            arcadeKart.baseStats = new ArcadeKart.Stats
            {
                // Assign new values here
                // For example:
                TopSpeed = 30f,
                Acceleration = 30f,
               
                AccelerationCurve = 4f,
                Braking = 10f,
                ReverseAcceleration = 5f,
                ReverseSpeed = 5f,
                Steer = 5f,
                CoastingDrag = 4f,
                Grip = .95f,
                AddedGravity = 1f,
                // Add other stat assignments as needed
            };
        }
        else
        {
            Debug.LogError("ArcadeKart component not found on the GameObject.");
        }
    }
}
