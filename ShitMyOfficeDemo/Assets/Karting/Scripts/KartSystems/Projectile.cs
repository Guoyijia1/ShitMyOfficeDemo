using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public QuadraticCurve curve;
    public float speed;


    private float sampleTime;


    private void Start()
    {
        sampleTime = 0f;
    }


    private void Update()
    {
        sampleTime += Time.deltaTime * speed;
        transform.position = curve.evaluate(sampleTime);
        transform.forward = curve.evaluate(sampleTime + 0.001f) - transform.position;

        if (sampleTime >= 1f)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
