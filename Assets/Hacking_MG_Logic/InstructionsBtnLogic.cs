using UnityEngine;
using UnityEngine.UI;

public class InstructionsBtnLogic : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject blocker;
    private bool isPanelActive = false;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowInstructions);
    }

    private void ShowInstructions()
    {
        isPanelActive = !isPanelActive;
        instructionsPanel.SetActive(isPanelActive);
        blocker.SetActive(isPanelActive);

        Time.timeScale = isPanelActive ? 0f : 1f; // Pause/Resume the game based on panel state

    }
}
