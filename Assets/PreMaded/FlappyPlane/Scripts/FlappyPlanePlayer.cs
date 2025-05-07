using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlappyPlanePlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float fowardSpeed = 3f;
    public bool isDead = false;
    public bool isStart = false;

    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    FlappyPlaneGameManager gameManager;
    void Start()
    {
        gameManager = FlappyPlaneGameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.simulated = false;
    }

    public void StartGame()
    {
        isStart = true;
        _rigidbody.simulated = true;
    }

    void Update()
    {
        if (!isStart) return;
        if (isDead)
        {
            if(deathCooldown <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject()) return;
                    gameManager.ResetGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isStart || isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = fowardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();
    }
}
