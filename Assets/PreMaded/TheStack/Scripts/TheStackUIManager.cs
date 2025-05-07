using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TheStackUIState
{
    Home,
    Game,
    Score
}
public class TheStackUIManager : MonoBehaviour
{
    static TheStackUIManager instance;
    public static TheStackUIManager Instance
    {
        get { return instance; }
    }

    TheStackUIState currentState = TheStackUIState.Home;
    TheStackHomeUI homeUI = null;
    TheStackGameUI gameUI = null;
    TheStackScoreUI scoreUI = null;

    TheStack theStack = null;

    private void Awake()
    {
        instance = this;

        theStack = FindObjectOfType<TheStack>();

        homeUI = GetComponentInChildren<TheStackHomeUI>(true);
        homeUI?.Init(this);
        gameUI = GetComponentInChildren<TheStackGameUI>(true);
        gameUI?.Init(this);
        scoreUI = GetComponentInChildren<TheStackScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(TheStackUIState.Home);
    }

    public void ChangeState(TheStackUIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(TheStackUIState.Game);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("MainTown");
    }

    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScore()
    {
        scoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ChangeState(TheStackUIState.Score);
    }
}
