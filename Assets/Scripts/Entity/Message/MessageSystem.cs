using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public RectTransform backGround;
    public TextMeshProUGUI message;

    public Vector2 padding;

    public void ShowDialogue(string dialogue)
    {
        message.text = dialogue;
        message.ForceMeshUpdate();

        Vector2 textSize = new Vector2(message.preferredWidth, message.preferredHeight); ;

        backGround.sizeDelta = textSize + padding;
    }
}
