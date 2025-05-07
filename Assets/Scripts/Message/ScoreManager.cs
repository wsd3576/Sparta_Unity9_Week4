using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //�ϳ��� ����� ���� �̱��� ����

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
            DontDestroyOnLoad(gameObject); //�ٸ� �������� ���� �޼��� ǥ���ؾ� �ϱ� ������ �ı����ϰ� ����

            FlappyScoreCount.text = $"0 / {requireTime}";
            StackScoreCount.text = $"0 / {requireStack}";
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //���� �ҷ��� �� �ش� ���� ���� ��ü�� �޾ƿ��� �Լ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("���� �ҷ��Խ��ϴ�. ������Ʈ�� ã���ϴ�.");
        if(scene.name == "MainTown")
        {
            StartCoroutine(AnimateScorePanel()); //���� ������ �̴ϰ��� �������θ� �����ֱ� ���� �ڷ�ƾ ����
        }
        flappyPlane = FindObjectOfType<FlappyPlaneGameManager>();
        theStack = FindObjectOfType<TheStack>();

        if (flappyPlane != null) isEnterFalppyPlane = true;
        else if (theStack != null) isEnterTheStack = true;
    }

    //�ε巯�� �������� ���� �ڷ�ƾ
    IEnumerator AnimateScorePanel()
    {
        RectTransform rect = scorePanel.GetComponent<RectTransform>();

        yield return StartCoroutine(MoveRectX(rect, -150f, 0.5f));

        //�� ������ �̴ϰ��Ӹ��� ���п��θ� Ȯ���ϴ� �κ�
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

    //�������� �����ϴ� �ڵ带 ���� �ڷ�ƾ
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

    //�̴ϰ��� FlappyPlane ���� ����
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

    //�̴ϰ��� TheStack ���� ����
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
