using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector2 minCamLimit;
    [SerializeField] private Vector2 maxCamLimit;

    void Awake()
    {
        target = FindAnyObjectByType<PlayerController>().gameObject.transform;
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
