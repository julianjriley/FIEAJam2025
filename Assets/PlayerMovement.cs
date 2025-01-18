using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    // Tap to move (stop rotating)
    // Hold to stop rotating

    private PlayerMovement _playerMovement;
    private Rigidbody2D _rb;
    public float ZRotation;
    public float Force;
    public int Player;

    private PlayerInput _playerInput;
    private PlayerControls _controls;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
        _controls = new PlayerControls();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Player.Player1.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldAbility();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };

        _controls.Player.Player2.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldAbility();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };

        _controls.Player.Player3.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldAbility();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };

        _controls.Player.Player4.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldAbility();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };
    }

    private void OnDisable()
    {
        _controls.Player.Player1.canceled -= context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldRelease();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };

        _controls.Player.Player2.canceled -= context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldRelease();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };

        _controls.Player.Player3.canceled -= context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldRelease();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };

        _controls.Player.Player4.canceled -= context =>
        {
            if (context.interaction is HoldInteraction)
            {
                HoldRelease();
            }
            else if (context.interaction is TapInteraction)
            {
                ApplyForce();
            }
        };
    }
    private void HoldAbility()
    {
        this.transform.Rotate(0,0,0);
        // stop rotation
    }

    private void HoldRelease()
    {
        // wait float seconds
        // continue rotation

        this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
    }

    private void TapRelease()
    {
        // wait float seconds
        // continue rotations
        this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
    }
    private void ApplyForce()
    {
        this.transform.Rotate(0, 0, 0);
        _rb.AddForce(transform.forward, ForceMode2D.Impulse);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Player is always rotating in a fixed position
        this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);

    }
}
