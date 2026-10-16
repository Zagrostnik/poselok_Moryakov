
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    public void AddScore(int amount)
    {
        Score += amount;
        Debug.Log("Счёт: " + Score);
    }

    public void ResetScore()
    {
        Score = 0;
        Debug.Log("Счёт сброшен");
    }
}
