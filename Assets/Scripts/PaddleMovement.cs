using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
   // Breakout Paddle Movement: move left and right and keep the paddle on screen

   [Header("Movement Settings")]
    public float moveSpeed = 7f; // speed of the paddle movement

    [Header("Breakout Movement Settings")]
    public float horizontalLeft = -7f; // left boundary for the paddle movement
    public float horizontalRight = 7f; // right boundary for the paddle movement

    private Vector2 movement; //stores the player input for movement
    private Rigidbody2D rBody; //refrence to the Rigidbody2D component for movement

    //runs when the object is created 
    private void Awake() 
    {
        rBody = GetComponent<Rigidbody2D>(); //get the Rigidbody2D component attached to the paddle for movement
    }

    //runs at a fixed time interval,for the  physics-based movement
    private void FixedUpdate()
    {
        float horizontalVelocity = movement.x * moveSpeed; //calculate the horizontal velocity based on player input and movement speed
        rBody.linearVelocity = new Vector2(horizontalVelocity, 0f); //sets the velcity of the paddle to move left or right

        //clamp the paddle's position to keep it within the horizontal boundaries of the screen
        Vector3 clampedPosition = transform.position; 
        clampedPosition.x = Mathf.Clamp(transform.position.x, horizontalLeft, horizontalRight);
        transform.position = clampedPosition;
    }

    //method is reads the input from the keyboard and stores the movement value
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();// read the left/right input and store it
    }
}
