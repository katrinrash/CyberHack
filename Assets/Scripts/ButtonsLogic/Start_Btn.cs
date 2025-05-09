using UnityEngine;
using UnityEngine.UI;

public class Start_Btn : MonoBehaviour
{
    private Button button;
    public GameObject toTurnOff;
    public GameObject mainGameUI;
    public TimerController timer;

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

    }
}
