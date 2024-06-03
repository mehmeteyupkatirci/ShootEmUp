using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int score = 0;
    public TextMeshProUGUI scoreText; // Skoru gösterecek TextMeshPro öğesi

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   private void Start()
{
    if (scoreText != null)
    {
        scoreText.text = ""; // Başlangıç metnini temizleyin
    }
    UpdateScoreText();
}

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // Sadece skoru göster
        }
    }
}
