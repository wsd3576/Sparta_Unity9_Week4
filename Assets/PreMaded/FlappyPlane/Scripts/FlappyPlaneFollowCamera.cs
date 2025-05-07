using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlaneFollowCamera : MonoBehaviour
{
    public Transform target;
    float offSetX;

    void Start()
    {
        if (target == null) return;

        offSetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offSetX;
        transform.position = pos;
    }
}
