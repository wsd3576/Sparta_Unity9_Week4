using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance;

    public MessageSystem messageSystem;

    private void Awake()
    {
        Instance = this;
        messageSystem = GetComponentInChildren<MessageSystem>(true);
    }
}
