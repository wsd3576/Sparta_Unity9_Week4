using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTown : MonoBehaviour
{
    public void ReturnTown()
    {
        SceneManager.LoadScene("MainTown");
    }
}
