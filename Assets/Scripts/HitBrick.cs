using UnityEngine;

public class HitBrick : MonoBehaviour
{
   public Bricks bricksManager; // reference to the Bricks manager

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
           if (bricksManager != null) // check if the reference to the Bricks manager is set before calling the LastBrick method
            {
                bricksManager.LastBrick(); // tell the manager one brick was removed
            }

            Destroy(gameObject); // remove the brick
        }
    } 
}
