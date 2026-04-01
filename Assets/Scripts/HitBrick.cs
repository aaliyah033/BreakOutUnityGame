using UnityEngine;

public class HitBrick : MonoBehaviour
{
   public Bricks bricksManager; // reference to the Bricks manager

   [Header("Audio Settings")]
    public AudioSource brickAudioSource; // brick hit sound effect

    private void Awake()
    {
        brickAudioSource = GetComponent<AudioSource>(); // get the AudioSource from the brick
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // play the brick hit sound effect
            if (brickAudioSource != null)
            {
                brickAudioSource.Play();
            }

            //for the screen shake (juice effect) - shake the camera when the brick is hit
            ScreenShake shake = Camera.main.GetComponent<ScreenShake>();
                if (shake != null) //check to make sure the ScreenShake script exists on the camera
            {
                shake.ShakeCamera(); // call the method to start the screen shake
            }

           if (bricksManager != null) // check if the reference to the Bricks manager is set before calling the LastBrick method
            {
                bricksManager.LastBrick(); // tell the manager one brick was removed
            }

            Destroy(gameObject, 0.2f); // remove the brick
        }
    } 
}
