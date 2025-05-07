using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour
{
    protected bool isPlayerInZone = false;

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInZone = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }
}
