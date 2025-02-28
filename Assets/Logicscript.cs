using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;  // L'écran Game Over

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString();
    }

    // Fonction qui redémarre le jeu lorsque l'on clique sur "Rejouer"
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recharge la scène actuelle pour redémarrer
    }

    // Fonction qui active l'écran Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);  // Affiche l'écran Game Over
    }
}