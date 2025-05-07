using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public GameObject scorePanel;
    public TextMeshProUGUI FlappyScoreCount;
    public TextMeshProUGUI StackScoreCount;

    private FlappyPlaneGameManager flappyPlane;
    private TheStack theStack;

    static bool isFlappyPlaneCleared = false;
    static bool isTheStackCleared = false;

    private bool isEnterFalppyPlane = false;
    private bool isEnterTheStack = false;

    float requireTime = 20f;
    int requireStack = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            FlappyScoreCount.text = $"0 / {requireTime}";
            StackScoreCount.text = $"0 / {requireStack}";
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("씬을 불러왔습니다. 오브젝트를 찾습니다.");
        if(scene.name == "MainTown")
        {
            StartCoroutine(AnimateScorePanel());
        }
        flappyPlane = FindObjectOfType<FlappyPlaneGameManager>();
        theStack = FindObjectOfType<TheStack>();

        if (flappyPlane != null) isEnterFalppyPlane = true;
        else if (theStack != null) isEnterTheStack = true;
    }

    IEnumerator AnimateScorePanel()
    {
        RectTransform rect = scorePanel.GetComponent<RectTransform>();

        yield return StartCoroutine(MoveRectX(rect, -150f, 0.5f));

        if (isEnterFalppyPlane)
        {
            isEnterFalppyPlane = false;
            if(!isFlappyPlaneCleared) FlappyScoreCount.text = "Fail";
        }
        else if (isEnterTheStack)
        {
            isEnterTheStack = false;
            if(!isTheStackCleared) StackScoreCount.text = "Fail";
        }

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(MoveRectX(rect, 150f, 0.5f));
    }

    IEnumerator MoveRectX(RectTransform rect, float targetX, float duration)
    {
        Vector2 startPos = rect.anchoredPosition;
        Vector2 endPos = new Vector2(targetX, startPos.y);
        float time = 0f;

        while (time < duration)
        {
            rect.anchoredPosition = Vector2.Lerp(startPos, endPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        rect.anchoredPosition = endPos;
    }

    private void Update()
    {
        if (flappyPlane != null && !isFlappyPlaneCleared && !flappyPlane.isGameOver)
        {
            UpdateFlappyScore();
        }

        if (theStack != null && !isTheStackCleared && !theStack.isGameOver)
        {
            UpdateStackScore();
        }
    }

    void UpdateFlappyScore()
    {
        if (flappyPlane.surviveTime >= requireTime)
        {
            FlappyScoreCount.text = "Clear!";
            isFlappyPlaneCleared = true;
            StartCoroutine(AnimateScorePanel());
        }
        else FlappyScoreCount.text = $"{flappyPlane.surviveTime:N2} / {requireTime}";
    }

    void UpdateStackScore()
    {
        if (theStack.Score >= requireStack)
        {
            StackScoreCount.text = "Celar!";
            isTheStackCleared = true;
            StartCoroutine(AnimateScorePanel());
        }
        else StackScoreCount.text = $"{theStack.Score} / {requireStack}";
    }
}
