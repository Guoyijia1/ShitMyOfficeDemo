using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public bool restartNow;
    private RecordPlayerTime RecordPlayerTime;
    void Start()
    {
        StartCoroutine(LoadTargetScene());
        RecordPlayerTime = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RecordPlayerTime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadTargetScene()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            restartNow = true;
            SceneManager.LoadScene(0);
            restartNow = false;
        }
        
    }
}
