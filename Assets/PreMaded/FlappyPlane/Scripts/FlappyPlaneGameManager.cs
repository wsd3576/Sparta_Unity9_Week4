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

        //재시작시에도 전의 값을 유지하는 static bool값 isRestart를 가지고 게임을 바로 시작할지 따지는 조건
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
        uiManager.scoreText.gameObject.SetActive(true);
        uiManager.ToggleFirstRunUI();
        player.StartGame();
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        surviveTime = 0f;

        uiManager.ToggleRestartTextUI();

        //플레이어프리퍼런스에 FlappyPlane의 최고점수를 갱신하는 부분
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

    //리셋할 경우 현재 활성화되어있는 씬을 다시 로드해 오는 함수
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
