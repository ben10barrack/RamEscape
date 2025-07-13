using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    private int score = 0;
    private int totalCollectibles = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        CountTotalCollectibles();
        UpdateScoreText();
    }

    void CountTotalCollectibles()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString() + " / " + totalCollectibles.ToString();
    }
}
