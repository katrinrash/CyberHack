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
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameUI.SetActive(false);  
    }


}
