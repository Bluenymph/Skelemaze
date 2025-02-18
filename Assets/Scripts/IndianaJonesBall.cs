using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaJonesBall : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3 (-50, 0, 0);

    private bool canGoIndiana = false;

    private void Update()
    {
        if (canGoIndiana)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
            transform.position -= Vector3.forward * 1.2f * Time.deltaTime;
        }

        if (transform.position.z < 18.3)
        {
            canGoIndiana = false;
            GetComponentInChildren<AudioSource>().Stop();
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

    public void GoIndiana()
    {
        canGoIndiana = true;
        GetComponentInChildren<AudioSource>().Play();
    }
}
