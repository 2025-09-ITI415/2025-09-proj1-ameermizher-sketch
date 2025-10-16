using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject basketballPrefab;   // Drag your prefab here
    public Transform ballSpawnPoint;      // Drag empty GameObject here
    public Transform hoop;                // Drag your hoop or target
    public float shootForce = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (basketballPrefab == null || ballSpawnPoint == null || hoop == null)
        {
            Debug.LogWarning("Shooter is missing references!");
            return;
        }

        // Spawn the ball
        GameObject ball = Instantiate(basketballPrefab, ballSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Calculate direction with a slight upward arc
        Vector3 direction = (hoop.position - ballSpawnPoint.position).normalized;
        direction.y += 0.3f; // give it some lift

        rb.AddForce(direction * shootForce, ForceMode.Impulse);
        Debug.Log("Ball shot!");
    }
}

