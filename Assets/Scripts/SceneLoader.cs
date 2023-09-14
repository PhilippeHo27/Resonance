using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncOperation.isDone)
        {
            // Get the loading progress. The value is between 0 (0%) and 1 (100%).
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100f) + "%");
            
            yield return null;
        }
    }
}