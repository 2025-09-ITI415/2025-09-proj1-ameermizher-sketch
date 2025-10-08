using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            score++;
            Debug.Log("Score! Total: " + score);
        }
    }
}
