using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    private float patternMoveSpeed = 0.6f;
    private Vector3 startPos;
    private float offsetValue = 70f;

    private SceneChange sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        sceneChange = GameObject.Find("SceneManagement").GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * patternMoveSpeed;

        if (transform.position.y > startPos.y + offsetValue)
        {
            transform.position = startPos;
        }

        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.M))
        {
            sceneChange.LoadNextScene();
        }
    }
}
