using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    private void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"SCORE: {score:D6}";
    }

    private void OnEnable()
    {
        Collectibles.OnItemCollected += AddScore;
    }

    private void OnDisable()
    {
        Collectibles.OnItemCollected -= AddScore;        
    }
}
