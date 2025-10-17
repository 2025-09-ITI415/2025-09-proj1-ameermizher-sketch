using UnityEngine;

public class Ground : MonoBehaviour

{public static GameObject POI;

    void OnCollisionEnter(Collision collision)
    {
        // When the ball hits the ground
        if (collision.gameObject.CompareTag("Basketball"))
        {
            // Destroy the ball after 2 seconds
            Destroy(collision.gameObject, 2f);

            // Optionally, tell the shooter to spawn a new ball
            Shooter shooter = FindObjectOfType<Shooter>();
            if (shooter != null)
            {
                shooter.Invoke("Shoot", 2.1f); // waits a bit, then shoots again
            }
        }
    }
}
