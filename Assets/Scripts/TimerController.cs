using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float TimeLeft { get; set; }
    public bool isTimerRunning { get; private set;}

    public TextMeshProUGUI timerText;


    public void StartTimer(float duration)
    {
        TimeLeft = duration;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    void Update()
    {
        if (!isTimerRunning)
            return;

        TimeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.CeilToInt(TimeLeft).ToString() + " sec.";

        if (TimeLeft <= 0)
        {
            isTimerRunning = false;
            GameFlowManager.Instance.GameOver();
        }

    }
}
