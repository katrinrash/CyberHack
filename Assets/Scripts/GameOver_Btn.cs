using UnityEngine;
using UnityEngine.UI;

public class GameOver_Btn : MonoBehaviour
{
    private Button button;
    public GameObject toTurnOff;
    public GameObject mainGameUI;
    public TimerController timer;
    public CombVizualizer comboVizualizer;
    public GridGenerator gridGenerator;
    public ResetBtnLogic resetBtnLogic;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        toTurnOff.SetActive(false);
        mainGameUI.SetActive(true);

        timer.StartTimer(duration: 30f);
        comboVizualizer.CreateTarget();
        gridGenerator.ResetGrid();
        resetBtnLogic.SetReset(amount: 5);

    }
}
