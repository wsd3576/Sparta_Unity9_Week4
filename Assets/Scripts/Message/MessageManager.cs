using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance; //�� �� �ƹ� ��ü�� ���� �����ϵ��� �̱��� ����

    public MessageSystem messageSystem;
    public RectTransform rectTransform;

    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();
        messageSystem = GetComponentInChildren<MessageSystem>(true); //��Ȱ��ȭ ���¿��� ��ü�� �ҷ�����
    }
}
