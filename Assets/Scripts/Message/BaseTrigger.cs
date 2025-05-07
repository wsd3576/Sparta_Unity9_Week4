using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour
{
    protected bool isPlayerInZone = false; //플레이어가 영역 안에 들어왔는지 확인하는 불값

    //플레이어가 영역안에 들어왔을 때 상속받은 클래스들을 위한 기본 함수
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) //플레이어 캐릭터의 Player태그 개체일 때만 
        {
            isPlayerInZone = true;
        }
    }

    //플레이어가 영역밖으로 나갔을 때 상속받은 클래스들을 위한 기본함수
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }
}
