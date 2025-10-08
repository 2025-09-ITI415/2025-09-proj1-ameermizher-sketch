using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public float shootForce = 500f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Camera.main.transform.forward * shootForce);
    }
}

