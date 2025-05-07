using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageTrigger : BaseTrigger
{
    [SerializeField] private string[] dialogues;
    private bool hasFunction;

    private int dialogueIndex = 0;

    private bool dialogueFinished = false;

    GameObject guideText;

    SceneTrigger sceneTrigger;
    ScoreTrigger scoreTrigger;

    private void Start()
    {
        gameObject = MessageManager.Instance.messageSystem.gameObject;
        sceneTrigger = transform.GetComponent<SceneTrigger>();
        scoreTrigger = transform.GetComponent<ScoreTrigger>();
        if (sceneTrigger != null || scoreTrigger != null) hasFunction = true;
        else hasFunction = false;
        guideText = gameObject.transform.Find("GuideText").gameObject;
    }

    private void Update()
    {
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.F))
        {
            if (dialogueIndex < dialogues.Length - 1)
            {
                dialogueIndex++;
                if (dialogueIndex == dialogues.Length - 1)
                {
                    guideText.SetActive(false);
                    dialogueFinished = true;
                }
                MessageManager.Instance.messageSystem.ShowDialogue(dialogues[dialogueIndex]);
            }
            else if (hasFunction && dialogueFinished)
            {
                if (sceneTrigger != null) sceneTrigger.ActiveFunction();
                else if (scoreTrigger != null) scoreTrigger.DisplayScoreInfo();
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        gameObject.SetActive(true);
        guideText.SetActive(true);
        MessageManager.Instance.messageSystem.ShowDialogue(dialogues[0]);
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerExit2D(collider);
        dialogueIndex = 0;
        gameObject.SetActive(false);
    }
}
