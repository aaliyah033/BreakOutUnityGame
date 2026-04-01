using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    // Expansion: Screen Shake (+15 XP): Implement a "Juice" effect where the Camera shakes slightly every time a brick is hit

    [Header("Shake Settings")]
    public float shakeDuration = 0.15f; // how long the shake lasts
    public float shakeAmount = 0.1f; // how much the camera shakes

    private Vector3 startPosition; // original camera position
    private float shakeTimer = 0f; // timer for the shake

    void Start()
    {
        startPosition = transform.position; // save the original position of the camera
    }

    private void Update() 
    {
        if (shakeTimer > 0)
        {
            // move the camera a little bit randomly while shaking
            float randomX = Random.Range(-shakeAmount, shakeAmount);
            float randomY = Random.Range(-shakeAmount, shakeAmount);

            transform.position = new Vector3( // apply the random shake to the camera's position
                startPosition.x + randomX, // shake the camera left and right
                startPosition.y + randomY, // shake the camera up and down
                startPosition.z // keep the original z position to avoid moving the camera forward or backward
            );

            shakeTimer -= Time.deltaTime; // count down the shake time
        }
        else
        {
            // reset the camera back to its original position
            shakeTimer = 0f;
            transform.position = startPosition;
        }
    }


    public void ShakeCamera()
    {
        shakeTimer = shakeDuration; // start the shake
    }
}
