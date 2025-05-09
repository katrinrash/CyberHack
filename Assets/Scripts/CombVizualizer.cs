using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombVizualizer : MonoBehaviour
{ 
    public TextMeshProUGUI targetcomboText;
    public TextMeshProUGUI choisesText;

    private CombGenerator combGenerator = new CombGenerator();
    public List<string> targetCombination { get; private set; }

    void Start()
    {
        CreateTarget();
    }

    public void CreateTarget()
    {
        targetCombination = combGenerator.GenerateCombination();
        targetcomboText.text = "Your Target: " + string.Join(" ", targetCombination);
        choisesText.text = "Your Choices: ";

        MiniGameManager.Instance.Init();
    }

    public void UpdateChoicesText(string value)
    {
        choisesText.text += value + " ";
    }

}
