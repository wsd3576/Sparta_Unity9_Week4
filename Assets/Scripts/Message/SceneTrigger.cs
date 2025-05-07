using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName; //�ҷ��� ���� �ν����� â���� �Է��ϱ� ���� SerializeField

    public void ActiveFunction()
    {
        Debug.Log($"{sceneName}�۵���");
        SceneManager.LoadScene(sceneName);
    }
}
