using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance; //�� �� �ƹ� ��ü�� ���� �����ϵ��� �̱��� ����

    public MessageSystem messageSystem;

    private void Awake()
    {
        Instance = this;
        messageSystem = GetComponentInChildren<MessageSystem>(true); //��Ȱ��ȭ ���¿��� ��ü�� �ҷ�����
    }
}
