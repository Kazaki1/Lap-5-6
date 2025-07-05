using UnityEngine;

public class Reward : MonoBehaviour
{
    public int scoreAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreAmount);

            Destroy(gameObject);
        }
    }
}
