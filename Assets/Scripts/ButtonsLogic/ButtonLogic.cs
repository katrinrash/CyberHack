using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string _value { get; private set; } 
    public int _row { get; private set; } 
    public int _column { get; private set; } 

    private Button button;
    private Image buttonBackground;
    private Color defaultColor;

    public void Setup(string value, int row, int column)
    { 
        _value = value;
        _row = row;
        _column = column;

        button = GetComponent<Button>();
        buttonBackground = GetComponent<Image>();
        defaultColor = buttonBackground.color;

        button.GetComponentInChildren<Text>().text = value; // Sets the text of the button to the value
        button.onClick.AddListener(OnButtonClick); // Adds a listener to the button click event
    }

    private void OnButtonClick()
    {
        MiniGameManager.Instance.OnButtonClick(this);
    }

    private void Highlight()
    {
        if(button.interactable)
        buttonBackground.color = Color.grey; 
    }

    private void Unhighlight()
    {
        if (button.interactable)
        buttonBackground.color = defaultColor; // Resets the button color to the default
    }

    public void Select()
    {
        buttonBackground.color = Color.green;
        button.interactable = false;
    }

    public void OnPointerEnter(PointerEventData eventData) => Highlight();
    public void OnPointerExit(PointerEventData eventData) => Unhighlight();

}
