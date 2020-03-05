using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput = 0;
    private float verticalInput = 0;
    public float movementSpeed = 0;
    public float rotationSpeed = 0;

    public Animator playerAnimator;

    Rigidbody2D rb2d;
    private bool _isFrozen;

    private void OnEnable()
    {
        EventManager.StartListening("FreezePlayer", FreezePlayer);
    }

    private void OnDisable()
    {
        EventManager.StopListening("FreezePlayer", FreezePlayer);
    }

    private void FreezePlayer()
    {
        _isFrozen = true;
        horizontalInput = 0;
        verticalInput = 0;
        rb2d.velocity = Vector3.zero;
        playerAnimator.SetFloat("PlayerVelocity", 0f);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isFrozen) return;
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        rb2d.velocity = transform.right * Mathf.Clamp01(verticalInput) * movementSpeed;
        playerAnimator.SetFloat("PlayerVelocity", Mathf.Abs(verticalInput));
    }
    
    private void RotatePlayer()
    {
        float rotation = -horizontalInput * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }
}



