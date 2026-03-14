using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball Settings")]
    public float ballBounce = 4.5f;   // speed of the ball

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // start the ball moving diagonally
        rb.linearVelocity = new Vector2(ballBounce, ballBounce);
    }
}
