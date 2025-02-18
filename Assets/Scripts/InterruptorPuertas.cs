using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPuertas : MonoBehaviour
{
    [SerializeField] private GameObject puerta;
    [SerializeField] private float doorSpeed = 3.0f;
    [SerializeField] private AudioClip feedbackSound;
    [SerializeField] private AudioClip doorFeedbackSound;
    [SerializeField] private bool on_switch_active = false;

    private Vector3 max_position = Vector3.zero;
    private bool can_go_down = true;
    private bool alreadyDone = false;

    private void Start()
    {
        if (puerta != null)
        {
            max_position = puerta.transform.position - new Vector3(0,5,0);
        }
    }

    private void Update()
    {
        if (on_switch_active & puerta != null & can_go_down)
        {
            puerta.transform.position += Vector3.down * doorSpeed * Time.deltaTime;
        }

        if (puerta.transform.position.y <= max_position.y)
        {
            can_go_down = false;
        }
    }



    public void InterruptorActivado()
    {
        if (!alreadyDone)
        {
            alreadyDone = true;
            GetComponentInChildren<AudioSource>().PlayOneShot(feedbackSound);
            puerta.GetComponentInChildren<AudioSource>().clip = doorFeedbackSound;
            puerta.GetComponentInChildren<AudioSource>().Play();
            on_switch_active = true;
        }
    }
}
