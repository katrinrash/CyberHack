using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // to do: still 2 audio listeners in the scene, need to fix it

    private int sceneIndex = 1; // Index of the minigame scene in the build settings
    public GameObject player; 
    public GameObject mainEventSystem;
    public GameObject containsAudioListener; 
    private ScreenViewController screenViewController;
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
       Instance = this;
    }

    public void LoadMinigameScene(ScreenViewController screenViewController)
    {
        this.screenViewController = screenViewController;
        StartCoroutine(LoadMinigameSceneCoroutine());
    }

    public void UnloadMinigameScene(float delay)
    {
       StartCoroutine(UnloadScene(delay));
    }

    private IEnumerator LoadMinigameSceneCoroutine()
    {
        mainEventSystem.SetActive(false);
        containsAudioListener.SetActive(false); // Disable the main event system and audio listener before loading the minigame scene, so no conflicts occur

        // AsyncLoading to show minigame over the main scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null; 
        }

        Scene loadedScene = SceneManager.GetSceneByName("Hacking_MiniGame");
        SceneManager.SetActiveScene(loadedScene);

        player.SetActive(false); 

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private IEnumerator UnloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneIndex);

        while (!asyncUnload.isDone)
        {
            yield return null;
        }

        player.SetActive(true);
        mainEventSystem.SetActive(true);
        containsAudioListener.SetActive(true); 

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        screenViewController.EnterScreenView();

    }

}
