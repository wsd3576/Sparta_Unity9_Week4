using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStackDestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Rubble")
        {
            Destroy(collision.gameObject);
        }
    }
}
