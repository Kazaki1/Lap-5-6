using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    public string gameOverSceneName = "GameOver";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit spike. Game Over!");

            Time.timeScale = 0f;

            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
