using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public bool restartNow;
    private RecordPlayerTime recordPlayerTime;
    void Start()
    {
        StartCoroutine(LoadTargetScene());
        recordPlayerTime = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RecordPlayerTime>();
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
            recordPlayerTime.p1End = false;
            recordPlayerTime.p2End = false;
            recordPlayerTime.finishP1Time = 0;
            recordPlayerTime.finishP2Time = 0;
            recordPlayerTime.finishTimeP1Text = "";
            recordPlayerTime.finishTimeP2Text = "";
            restartNow = false;
            Destroy(GameObject.FindGameObjectWithTag("GameManager"));
        }
        
    }
}
