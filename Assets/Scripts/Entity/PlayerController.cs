using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : BaseController
{
    private new Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    //InputSystem의 플레이어 인풋에 등록되어있는 입력들
    void OnMove(InputValue inputValue) //W,A,S,D 입력시
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnLook(InputValue inputValue) //마우스 이동시
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPosition = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPosition - (Vector2)transform.position);

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnJump(InputValue inputValue) //스페이스바 입력시
    {
        IsJump = inputValue.isPressed;
    }

    void OnSprint(InputValue inputValue) //쉬프드 입력시
    {
        IsSprint = inputValue.isPressed;
    }
}
