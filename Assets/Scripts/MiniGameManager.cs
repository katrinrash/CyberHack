using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }
    public CombVizualizer comboVizualizer;
    public TimerController timerController;

    public List<int> currentCombo { get; private set;}
    private List<string> comboCheck = new List<string>();
    private bool isHorizontalTurn;
    private (int lastRow,int lastColumn) positionData; // tuple
    private int elementIndex;

    private void Awake()
    {
       Instance = this;
    }

    public void Init()
    {
        currentCombo = new List<int>();
        comboCheck = comboVizualizer.targetCombination;
        elementIndex = 0;
        isHorizontalTurn = true;
        positionData = (0, 0);
    }

    public void OnButtonClick(ButtonLogic button)
    {
        if (elementIndex >= comboCheck.Count || button._value != comboCheck[elementIndex])
            return;

        if (currentCombo.Count == 0 && button._row == 0) 
        {
            AcceptButton(button);
            return;
        }

        if ((isHorizontalTurn && button._row == positionData.lastRow) || (!isHorizontalTurn && button._column == positionData.lastColumn))
        {
            AcceptButton(button);
        }

    }

    private void AcceptButton(ButtonLogic btn)
    {
        btn.Select();
        elementIndex++;
        comboVizualizer.UpdateChoicesText(btn._value);
        currentCombo.Add(elementIndex);

        if(currentCombo.Count == comboCheck.Count)
        {
            timerController.StopTimer();
            GameFlowManager.Instance.WinGame();
        }

        positionData.lastRow = btn._row;
        positionData.lastColumn = btn._column;
        isHorizontalTurn = !isHorizontalTurn;
    }

}
