using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{
    /*
    public string Player1Position = "A";
    public string Player2Position = "B";
    public string PlayersMiddlePosition = "Control";
    */
    public GameObject a;
    public GameObject b;
    public GameObject control;

    


    private Transform aPosition;
    private Transform bPosition;
    private Transform controlPosition;

    //public string targetTag = "YourTargetTag";

    void Update()
    {
        GameObject a = GameObject.FindGameObjectWithTag("PositionA");

       // GameObject a = GameObject.Find("Player1");
        GameObject b = GameObject.Find("Player2");
        GameObject control = GameObject.Find("Sphere");

/*
        Vector3 aPosition = a.transform.position;
        Vector3 bPosition = b.transform.position;
        Vector3 controlPosition = control.transform.position;
*/
        Transform aPosition = a.transform;
        Transform bPosition = b.transform;
        Transform controlPosition = control.transform;

        // Transform player1position = Player1Position.transform;

    }


    public Vector3 evaluate(float t)
    {
        Vector3 ac = Vector3.Lerp(aPosition.position, controlPosition.position, t);
        Vector3 cb = Vector3.Lerp(controlPosition.position, bPosition.position, t);
        return Vector3.Lerp(ac, cb, t);

    }

    private void OnDrawGizmos()
    {
        if (aPosition == null || bPosition == null || controlPosition == null)
        {
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            Gizmos.DrawWireSphere(evaluate(i / 20f), 0.1f);
        }
    }

    /*

    public GameObject Player1Position;
    public GameObject Player2Position;
    public GameObject PlayersMiddlePosition;


    private Transform player1position;
    private Transform player2position;
    private Transform playerMiddleposition;




    void Update()
    {
        Transform player1position = Player1Position.transform;
        Transform player2position = Player2Position.transform;
        Transform playerMiddleposition = PlayersMiddlePosition.transform;

    }


    public Vector3 evaluate(float t)
    {
        Vector3 ac = Vector3.Lerp(player1position.position, playerMiddleposition.position, t);
        Vector3 cb = Vector3.Lerp(playerMiddleposition.position, player2position.position, t);
        return Vector3.Lerp(ac, cb, t);

    }

    private void OnDrawGizmos()
    {
        if (player1position == null || player2position == null || playerMiddleposition == null)
        {
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            Gizmos.DrawWireSphere(evaluate(i / 20f), 0.1f);
        }
    }
    */


    /*
     public Transform A;
     public Transform B;
     public Transform Control;

     public Vector3 evaluate(float t)
     {
         Vector3 ac = Vector3.Lerp(A.position, Control.position, t);
         Vector3 cb = Vector3.Lerp(Control.position, B.position, t);
         return Vector3.Lerp(ac, cb, t);

     }

     private void OnDrawGizmos()
     {
         if (A == null || B == null || Control == null)
         {
             return;
         }

         for (int i = 0; i < 20; i++)
         {
             Gizmos.DrawWireSphere(evaluate(i / 20f), 0.1f);
         }
     }

    */

}
