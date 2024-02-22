using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersOnboarding : MonoBehaviour
{
    public Onboarding player1;
    public Onboarding player2;
    private SceneChange sceneChange;
    void Start()
    {
        sceneChange = GameObject.Find("SceneManagement").GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.player1Seated && player2.player2Seated)
        {
            Debug.Log("true");
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3f);
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackGroundMusic>().StopMusic();
        sceneChange.LoadNextScene();
    }
}
