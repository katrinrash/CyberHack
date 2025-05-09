using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }
    public GameObject gameOverUI;
    public GameObject winUI;
    public GameObject gameUI;

    private void Awake()
    {
        Instance = this;
    }

    public void WinGame()
    {
        gameUI.SetActive(false);
        winUI.SetActive(true);
        SceneLoader.Instance.UnloadMinigameScene(2f);
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameUI.SetActive(false);  
    }


}
