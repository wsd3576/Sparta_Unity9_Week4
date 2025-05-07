using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneGameManager : MonoBehaviour
{
    static FlappyPlaneGameManager gameManager;
    public static FlappyPlaneGameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    private static bool isRestart = false;

    public float surviveTime = 0f;

    public bool isGameOver = true;

    FlappyPlanePlayer player;
    FlappyPlaneUIManager uiManager;
    public FlappyPlaneUIManager UIManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<FlappyPlaneUIManager>();
        player = FindObjectOfType<FlappyPlanePlayer>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        if (isRestart)
        {
            uiManager.FirstRun.SetActive(false);
            StartGame();
            isRestart = false;
        }
    }

    private void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        UIManager.scoreText.gameObject.SetActive(true);
        uiManager.ToggleFirstRunUI();
        player.StartGame();
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        surviveTime = 0f;

        uiManager.ToggleRestartTextUI();

        int bestScore = PlayerPrefs.GetInt("FlappyPlaneBestScore", 0);
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("FlappyPlaneBestScore", currentScore);
            PlayerPrefs.Save();
            bestScore = currentScore;
        }
        uiManager.bestScoreText.text = bestScore.ToString();

        isRestart = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
