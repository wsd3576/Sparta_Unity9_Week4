using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public RectTransform backGround;
    public TextMeshProUGUI message;

    public Vector2 padding;

    //텍스트 내용을 바꾸는 함수
    public void ShowDialogue(string dialogue)
    {
        message.text = dialogue;
        message.ForceMeshUpdate(); //바뀐 텍스트의 크기를 정확히 재기 위해 정보를 업데이트

        Vector2 textSize = new Vector2(message.preferredWidth, message.preferredHeight); ;

        backGround.sizeDelta = textSize + padding;
    }
}
