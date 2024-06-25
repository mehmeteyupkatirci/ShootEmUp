using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false); // Oyun başladığında GameOverPanel'i gizle
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        gameOverUI.SetActive(false); // GameOverPanel'i gizle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        gameOverUI.SetActive(false); // GameOverPanel'i gizle
        SceneManager.LoadScene("MainScene"); // Ana menü sahnesinin adını buraya yazın
    }
}
