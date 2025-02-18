using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPinchos : MonoBehaviour
{
    private bool playerOnArea = false;
    private bool canGoDown = true;
    private Vector3 initialPos = Vector3.zero;
    private float maxYDown = 0;


    private void OnEnable()
    {
        PlayerController.OnPlayerDead += ResetPichos;
    }

    private void Start()
    {
        maxYDown = transform.position.y - 10;
        initialPos = transform.position;
    }

    private void Update()
    {
        if (playerOnArea & canGoDown)
        {
            transform.position += Vector3.down * 1.2f *  Time.deltaTime;
        }

        if (transform.position.y <= maxYDown)
        {
            canGoDown = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerScript = other.GetComponentInParent<PlayerController>();
        if (playerScript)
        {
            print("Player muerto");
            playerScript.Death();

        }
    }

    public void ResetPichos()
    {
        transform.position = initialPos;
        playerOnArea = false;
        canGoDown = true;
    }

    public void PlayerOnArea()
    {
        if(!playerOnArea) GetComponentInChildren<AudioSource>().Play();
        playerOnArea = true;
    }
}
