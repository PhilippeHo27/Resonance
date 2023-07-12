using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This function can be called from UI button or other game objects
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Optional: you can display a loading screen or a progress bar while the scene is loading.
        while (!asyncOperation.isDone)
        {
            // Get the loading progress. The value is between 0 (0%) and 1 (100%).
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100f) + "%");

            // Yield control to Unity and resume the next frame.
            yield return null;
        }
    }
}