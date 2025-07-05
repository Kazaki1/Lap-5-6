using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public Vector2 moveDirection = Vector2.right;

    [Header("Game Over Settings")]
    public string gameOverSceneName = "GameOver";
    public float delayBeforeGameOver = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            moveDirection *= -1;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit spike. Game Over!");
            StartCoroutine(GoToGameOver());
        }
    }

    private System.Collections.IEnumerator GoToGameOver()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(delayBeforeGameOver);
        SceneManager.LoadScene(gameOverSceneName);
    }
}
