using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheStackGameUI : TheStackBaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;
    TextMeshProUGUI maxComboText;
    protected override TheStackUIState GetUIState()
    {
        return TheStackUIState.Game;
    }

    public override void Init(TheStackUIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
        maxComboText = transform.Find("MaxComboText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score, int combo, int maxCombo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        maxComboText.text = maxCombo.ToString();
    }
}
