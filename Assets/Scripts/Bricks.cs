using UnityEngine;

public class Bricks : MonoBehaviour {

    [Header("Brick Settings")]
    public GameObject[] brickPrefabs; //array to hold different types of brick prefabs that can be randomly selected when instantiating bricks

// For the brick wall size and position 
    [Header("Wall Settings")]
    public int rows = 5; //number of rows of bricks to create
    public int columns = 7; //number of columns of bricks to create
    public float startX = -4.5f; // for where the wall starts on the X axis (left/right)
    public float startY = 3.2f;  // for where the wall starts on the Y axis (up/down)
    public float xSpacing = 1.8f; //adding space between bricks horizontally
    public float ySpacing = 1f; //adding space between bricks vertically

    void Start()
    {
         
        for (int row = 0; row < rows; row++) //this is loop through each row
        {
            for (int column = 0; column < columns; column++) //this is loop through each column in the current row
            {
                Vector3 brickPosition = new Vector3( // calculate the position where the brick should be instantiated
                    startX + column * xSpacing, //calculate the x position based on the column index and spacing -> x= left / right
                    startY - row * ySpacing, //calculate the y position based on the row index and spacing -> y= up / down
                    0 //keep the z position at 0 since it's a 2D game
                );
                // Randomly select a brick prefab from the array of brick prefabs to add variety to the wall
                int randomIndex = Random.Range(0, brickPrefabs.Length);
                // create a brick at this position and make it appear
                Instantiate(brickPrefabs[randomIndex], brickPosition, Quaternion.identity);
            }
        }
    }
}