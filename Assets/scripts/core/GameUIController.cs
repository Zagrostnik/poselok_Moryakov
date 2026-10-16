
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;

    private ScoreManager scoreManager;

    private void Update()
    {
        if (scoreManager == null)
        {
            scoreManager = FindFirstObjectByType<ScoreManager>();
            return;
        }

        if (scoreText != null)
        {
            scoreText.text = "СЧЁТ: " + scoreManager.Score;
        }

        if (finalScoreText != null)
        {
            finalScoreText.text =
                "ИТОГОВЫЙ СЧЁТ: " + scoreManager.Score;
        }
    }
}
