using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Propiedades")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 100f;

    public static event Action OnPlayerDead;

    private CharacterController characterController;
    private Vector3 initialPosition = Vector3.zero;

    void Start()
    {
        initialPosition = transform.position;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();

        //Raycast
        if (Input.GetMouseButtonDown(0) & Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2f))
        {
            print("Raycast golpeo con: "+ hit.collider.name);
            InterruptorPuertas interruptor = hit.collider.GetComponentInParent<InterruptorPuertas>();
            if (interruptor != null)
            {
                interruptor.InterruptorActivado();
            }
        }
    }

    void Movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = transform.forward * verticalInput * moveSpeed;

        characterController.SimpleMove(moveDirection);

        float finalRotation = rotationInput * rotateSpeed * Time.deltaTime;
        transform.Rotate(0,finalRotation,0);
    }

    public void Death()
    {
        characterController.enabled = false;
        transform.position = initialPosition;
        OnPlayerDead?.Invoke();
        characterController.enabled = true;
    }
}
