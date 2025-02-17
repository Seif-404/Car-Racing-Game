using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string gameSceneName = "SampleScene"; 

    public void PlayGame()
    {
        StartCoroutine(LoadGameSceneWithDelay());
    }

    private IEnumerator LoadGameSceneWithDelay()
    {
       
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(gameSceneName);
    }
}
