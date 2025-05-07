using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TheStackBaseUI : MonoBehaviour
{
    protected TheStackUIManager uiManager;

    public virtual void Init(TheStackUIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract TheStackUIState GetUIState();
    public void SetActive(TheStackUIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
