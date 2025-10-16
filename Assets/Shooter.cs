
    using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject basketballPrefab;   // Assign your ball prefab
    public Transform ballSpawnPoint;      // Empty GameObject at shooter’s hand
    public float shootForce = 10f;        // Strength of the throw
    public Transform hoop;                // The target to aim at

    void Update()
    {
        // Left mouse button click to shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create the basketball
        GameObject ball = Instantiate(basketballPrefab, ballSpawnPoint.position, Quaternion.identity);

        // Add physics force
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null && hoop != null)
        {
            // Direction from shooter to hoop
            Vector3 direction = (hoop.position - ballSpawnPoint.position).normalized;

            // Add upward arc to make it realistic
            direction.y += 0.3f;

            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
}

