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
    public float xSpacing = 1.5f; //adding space between bricks horizontally
    public float ySpacing = 1f; //adding space between bricks vertically

    // for Gate 2: Win Condition. Detect when the last brick is destroyed and display a "You Win" UI screen.
    [Header("Win Condition Settings")]
    public GameObject winScreen; // reference to the UI element that will be displayed when the player wins
    
    private int totalBricks; // variable to keep track of the total number of bricks in the wall
    
    void Start()
    {
        totalBricks = rows * columns; // calculate the total number of bricks based on the number of rows and columns
        if (winScreen != null)
        {
            winScreen.SetActive(false); // Ensure the win screen is hidden at the start of the game
        }
        
        //this nested loop for the brick wall
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
                GameObject newBrick = Instantiate(brickPrefabs[randomIndex], brickPosition, Quaternion.identity);

                // for Gate 2: Win Condition. Detect when the last brick is destroyed and display a "You Win" UI screen.
                HitBrick hitBrickScript = newBrick.GetComponent<HitBrick>();

                if (hitBrickScript != null)
                {
                    hitBrickScript.bricksManager = this; // give each brick a reference to this manager
                }
            }
        }
    }
    //this method is called by the HitBrick script when a brick is destroyed. It decreases the brick count and checks if all bricks are destroyed to trigger the win condition.
    public void LastBrick()
    {
        totalBricks--; // subtract one when a brick is destroyed

        if (totalBricks <= 0) // check if all bricks are destroyed
        {
            if (winScreen != null) // check if the winScreen reference is set before trying to activate it
            {
                winScreen.SetActive(true); // show the You Win panel
            }

            Time.timeScale = 0f; // stop the game
        }
    }
}