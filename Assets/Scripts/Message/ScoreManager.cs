using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //하나만 남기기 위해 싱글톤 생성

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
            DontDestroyOnLoad(gameObject); //다른 씬에서도 조건 달성시 표시해야 하기 때문에 파괴안하게 설정

            FlappyScoreCount.text = $"0 / {requireTime}";
            StackScoreCount.text = $"0 / {requireStack}";
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //씬을 불러올 때 해당 씬에 있을 개체를 받아오는 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("씬을 불러왔습니다. 오브젝트를 찾습니다.");
        if(scene.name == "MainTown")
        {
            StartCoroutine(AnimateScorePanel()); //마을 씬에서 미니게임 성공여부를 보여주기 위한 코루틴 실행
        }
        flappyPlane = FindObjectOfType<FlappyPlaneGameManager>();
        theStack = FindObjectOfType<TheStack>();

        if (flappyPlane != null) isEnterFalppyPlane = true;
        else if (theStack != null) isEnterTheStack = true;
    }

    //부드러운 움직임을 위한 코루틴
    IEnumerator AnimateScorePanel()
    {
        RectTransform rect = scorePanel.GetComponent<RectTransform>();

        yield return StartCoroutine(MoveRectX(rect, -150f, 0.5f));

        //각 입장한 미니게임마다 실패여부를 확인하는 부분
        yield return new WaitForSeconds(0.5f);

        string originalString = null;
        if (isEnterFalppyPlane && !isFlappyPlaneCleared)
        {
            originalString = FlappyScoreCount.text;
            FlappyScoreCount.text = "Fail";
        }
        else if (isEnterTheStack && !isTheStackCleared)
        {
            originalString = StackScoreCount.text;
            StackScoreCount.text = "Fail";
        }

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(MoveRectX(rect, 150f, 0.5f));

        if (isEnterFalppyPlane && !isFlappyPlaneCleared)
        {
            FlappyScoreCount.text = originalString;
        }
        else if (isEnterTheStack && !isTheStackCleared)
        {
            StackScoreCount.text = originalString;
        }
        isEnterFalppyPlane = false;
        isEnterTheStack = false;
    }

    //움직임을 구현하는 코드를 묶은 코루틴
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

    //미니게임 FlappyPlane 성공 여부
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

    //미니게임 TheStack 성공 여부
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
