using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyPlaneUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;
    public GameObject FirstRun;
    public GameObject ExitButton;

    bool firstRunToggle = false;
    bool restartTextToggle = true;

    public void ToggleFirstRunUI()
    {
        FirstRun.SetActive(firstRunToggle);
        firstRunToggle = !firstRunToggle;
    }

    public void ToggleRestartTextUI()
    {
        restartText.gameObject.SetActive(restartTextToggle);
        bestScoreText.gameObject.SetActive(restartTextToggle);
        ExitButton.SetActive(restartTextToggle);
        restartTextToggle = !restartTextToggle;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
