using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheStackHomeUI : TheStackBaseUI
{
    Button startButton;

    protected override TheStackUIState GetUIState()
    {
        return TheStackUIState.Home;
    }

    public override void Init(TheStackUIManager uiManager)
    {
        base.Init(uiManager);

        startButton = transform.Find("StartButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }
}
