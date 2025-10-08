using UnityEngine;

public class HoopTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Score!");
            FindObjectOfType<GameManager>().AddScore(1);
        }
    }
}
