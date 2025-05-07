using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName; //불러올 씬을 인스팩터 창에서 입력하기 위한 SerializeField

    public void ActiveFunction()
    {
        Debug.Log($"{sceneName}작동중");
        SceneManager.LoadScene(sceneName);
    }
}
