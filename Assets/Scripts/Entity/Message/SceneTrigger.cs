using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : BaseTrigger
{
    [SerializeField] private string sceneName;


    public void ActiveFunction()
    {
        Debug.Log($"{sceneName}¿€µø¡ﬂ");
        SceneManager.LoadScene(sceneName);
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerExit2D(collider);
    }
}
