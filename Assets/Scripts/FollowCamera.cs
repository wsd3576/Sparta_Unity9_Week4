using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public Vector2 minCamLimit;
    public Vector2 maxCamLimit;

    void Start()
    {
        if (target == null) return;
    }

    void Update()
    {
        if (target == null) return;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(target.position.x, minCamLimit.x, maxCamLimit.x);
        pos.y = Mathf.Clamp(target.position.y, minCamLimit.y, maxCamLimit.y);
        transform.position = pos;
    }
}
