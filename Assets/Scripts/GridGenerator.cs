using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform container;

    private string[] possibleElements = { "A7", "B5", "D9", "0E" };

    private int gridLength = 5;

    void Start()
    {
        GenerateGrid(); 
    }

    public void GenerateGrid()
    { 
        for (int i = 0; i < gridLength * gridLength; i++)
        {            
            GameObject button = Instantiate(buttonPrefab, container); // Creates a new button in the specific container inside the scene

            var buttonLogic = button.GetComponent<ButtonLogic>();

            buttonLogic.Setup(
                possibleElements[Random.Range(0, possibleElements.Length)], // Randomly selects an element from the array
                i / gridLength, // Row index
                i % gridLength // Column index
                );
        }

    }

    public void ResetGrid()
    {
        ClearGrid();
        GenerateGrid();
    }

    private void ClearGrid()
    {
        foreach (Transform btn in container)
        {
            Destroy(btn.gameObject);
        }
    }

}
