using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour
{
    protected bool isPlayerInZone = false; //�÷��̾ ���� �ȿ� ���Դ��� Ȯ���ϴ� �Ұ�

    //�÷��̾ �����ȿ� ������ �� ��ӹ��� Ŭ�������� ���� �⺻ �Լ�
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) //�÷��̾� ĳ������ Player�±� ��ü�� ���� 
        {
            isPlayerInZone = true;
        }
    }

    //�÷��̾ ���������� ������ �� ��ӹ��� Ŭ�������� ���� �⺻�Լ�
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }
}
