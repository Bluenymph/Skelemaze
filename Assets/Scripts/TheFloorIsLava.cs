using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFloorIsLava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerScript = other.GetComponentInParent<PlayerController>();
        if (playerScript)
        {
            print("Player muerto");
            playerScript.Death();

        }
    }
}
