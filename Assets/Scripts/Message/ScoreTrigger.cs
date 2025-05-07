using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    int TheStackbestScore = 0;
    public int TheStackBestScore { get => TheStackbestScore; }
    int TheStackbestCombo = 0;
    public int TheStackBestCombo { get => TheStackbestCombo; }
    int FlappyPlanebestScore = 0;
    public int FlappyPlaneBestScore { get => FlappyPlanebestScore; }

    private const string TheStackBestScoreKey = "TheStackBestScore";
    private const string TheStackBestComboKey = "TheStackBestCombo";
    private const string FlappyPlaneBestScoreKey = "FlappyPlaneBestScore";

    private bool yetPlayedTheStack;
    private bool yetPlayedFlappyPlane;

    private string TheStackScoreMessage;
    private string FlappyPlaneScoreMessage;

    private void Start()
    {
        TheStackbestScore = PlayerPrefs.GetInt(TheStackBestScoreKey, 0);
        TheStackbestCombo = PlayerPrefs.GetInt(TheStackBestComboKey, 0);
        FlappyPlanebestScore = PlayerPrefs.GetInt(FlappyPlaneBestScoreKey, 0);

        if (TheStackbestScore == 0 && TheStackbestCombo == 0) yetPlayedTheStack = true;
        if (FlappyPlanebestScore == 0) yetPlayedTheStack = true;

        if (yetPlayedFlappyPlane) FlappyPlaneScoreMessage = "You played FlappyPlane yet.";
        else FlappyPlaneScoreMessage = $"Your HighScore of FlappyPlane is... \n Score : {FlappyPlanebestScore}";

        if (yetPlayedTheStack) TheStackScoreMessage = "You played TheStack yet.";
        else TheStackScoreMessage = $"Your HighScore of The Stack is... \n Score : {TheStackbestScore} Combo : {TheStackbestCombo}";
    }

    public void DisplayScoreInfo()
    {
        StartCoroutine(DisplayMessagesSequentially()); //순서대로 미니게임 기록을 불러오는 코루틴
    }

    private IEnumerator DisplayMessagesSequentially()
    {
        MessageManager.Instance.messageSystem.ShowDialogue(FlappyPlaneScoreMessage);

        yield return new WaitForSeconds(2.5f);

        MessageManager.Instance.messageSystem.ShowDialogue(TheStackScoreMessage);
    }
}
