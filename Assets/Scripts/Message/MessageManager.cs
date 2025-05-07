using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance; //맵 안 아무 개체나 접근 가능하도록 싱글톤 생성

    public MessageSystem messageSystem;
    public RectTransform rectTransform;

    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();
        messageSystem = GetComponentInChildren<MessageSystem>(true); //비활성화 상태여도 개체를 불러오기
    }
}
