using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageTrigger : BaseTrigger
{
    [SerializeField] private string[] dialogues;

    private int dialogueIndex = 1;
    private bool dialogueFinished = false;
    private bool hasFunction;

    GameObject messageObject;
    GameObject guideText;

    SceneTrigger sceneTrigger;
    ScoreTrigger scoreTrigger;

    private void Start()
    {
        messageObject = MessageManager.Instance.messageSystem.gameObject;
        guideText = messageObject.transform.Find("GuideText").gameObject;

        sceneTrigger = transform.GetComponent<SceneTrigger>();
        scoreTrigger = transform.GetComponent<ScoreTrigger>();
        hasFunction = (sceneTrigger != null || scoreTrigger != null);
    }

    private void Update()
    {
        if (!isPlayerInZone) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueFinished)
            {
                MessageManager.Instance.messageSystem.ShowDialogue(dialogues[dialogueIndex]);
                dialogueIndex++;

                if (dialogueIndex >= dialogues.Length)
                {
                    guideText.SetActive(false);
                    dialogueFinished = true;
                }
            }
            else if (hasFunction)
            {
                if (sceneTrigger != null) sceneTrigger.ActiveFunction();
                else if (scoreTrigger != null) scoreTrigger.DisplayScoreInfo();
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        messageObject.SetActive(true);
        guideText.SetActive(true);

        dialogueIndex = 1;
        dialogueFinished = false;
        MessageManager.Instance.messageSystem.ShowDialogue(dialogues[0]);
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerExit2D(collider);
        messageObject.SetActive(false);

        dialogueIndex = 1;
        dialogueFinished = false;
    }
}
