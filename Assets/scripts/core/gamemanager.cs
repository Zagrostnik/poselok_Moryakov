
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;

    public bool IsGameOver { get; private set; }

    private static bool startImmediately;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (startImmediately)
        {
            startImmediately = false;
            StartGame();
        }
        else
        {
            ShowMainMenu();
        }
    }

    public void StartGame()
    {
        IsGameOver = false;

        SetPanel(mainMenuPanel, false);
        SetPanel(hudPanel, true);
        SetPanel(gameOverPanel, false);

        ScoreManager scoreManager =
            FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;

        SetPanel(hudPanel, false);
        SetPanel(gameOverPanel, true);

        Time.timeScale = 0f;
    }

    public void ShowMainMenu()
    {
        IsGameOver = false;

        SetPanel(mainMenuPanel, true);
        SetPanel(hudPanel, false);
        SetPanel(gameOverPanel, false);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        startImmediately = true;
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void ReturnToMenu()
    {
        startImmediately = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetPanel(GameObject panel, bool active)
    {
        if (panel != null)
        {
            panel.SetActive(active);
        }
    }
}
