using UnityEngine;

using UnityEngine;

public class BasketballShooter : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    public float shootForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        isHeld = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isHeld = false;
        rb.isKinematic = false;

        // Shoot forward and upward
        rb.AddForce(new Vector3(0, 1, 1) * shootForce, ForceMode.Impulse);
    }

    void Update()
    {
        if (isHeld)
        {
            // Make ball follow mouse position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // distance from camera
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos;
        }
    }
}

