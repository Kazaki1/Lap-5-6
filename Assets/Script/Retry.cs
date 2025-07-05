using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public string levelToReload = "Lv1"; 

    public void RetryGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(levelToReload);
    }
}
