using UnityEngine;

public class GridInitializer : MonoBehaviour
{
    public GameObject itemPrefab;      // Prefab of the item to place in the grid (e.g., card)
    public int rows = 3;               // Number of rows in the grid
    public int columns = 3;            // Number of columns in the grid
    public float spacing = 1.5f;       // Spacing between each item in the grid
    public Vector3 startingPosition = new Vector3(0, 0, 0); // Position to start the grid (top-left corner)

    private GameObject[,] gridItems;   // 2D array to hold references to the grid items

    void Start()
    {
        InitializeGrid();
    }

    // Method to initialize the grid
    void InitializeGrid()
    {
        gridItems = new GameObject[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Calculate the position of each item in the grid
                Vector3 position = startingPosition + new Vector3(j * spacing, 0, -i * spacing);

                // Instantiate the item prefab and set its position
                GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);

                // Optionally, set the parent to organize the hierarchy in the scene
                newItem.transform.parent = transform;

                // Store the reference of the instantiated item in the gridItems array
                gridItems[i, j] = newItem;
            }
        }
    }
}
