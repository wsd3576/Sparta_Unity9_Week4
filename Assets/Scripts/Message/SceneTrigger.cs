using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ActiveFunction()
    {
        Debug.Log($"{sceneName}¿€µø¡ﬂ");
        SceneManager.LoadScene(sceneName);
    }
}
