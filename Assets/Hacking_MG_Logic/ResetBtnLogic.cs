using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtnLogic : MonoBehaviour
{
    private Button button;
    public GridGenerator gridGenerator;
    public TextMeshProUGUI infoText;

    private int amountOfResets = 5; 

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        infoText.text = "Resets left: " + amountOfResets;
    }

    public void SetReset(int amount)
    {
        amountOfResets = amount;
        infoText.text = "Resets left: " + amountOfResets;
        button.interactable = true;
    }

    private void OnButtonClick()
    {
       if(amountOfResets == 0 || MiniGameManager.Instance.currentCombo.Count > 0)
       {
            infoText.text = "Reset is not allowed";
            button.interactable = false;
            return;
       }

       gridGenerator.ResetGrid();
       amountOfResets--;
       infoText.text = "Resets left: " + amountOfResets;
    }
}
