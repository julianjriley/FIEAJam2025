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
    [SerializeField]
    private int _player;

    private bool _hasControl;
    private bool _isHeld = false;
    private bool _isTap = false;
    private bool _hasItem = false;

    private float _holdDuration;
    private PlayerControls _controls;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _controls = new PlayerControls();

        switch(_player)
        {
            case 1:
                Debug.Log("Player 1 is the current player");
                _controls.Player.Player1.Enable();
                break;
            case 2:

                _controls.Player.Player2.Enable();
                break;
            case 3:

                _controls.Player.Player3.Enable();
                break;
            case 4:

                _controls.Player.Player4.Enable();
                break;
        }

    }

    private void OnEnable()
    {
       
        //_controls.Player.Player2.performed += context =>
        //{
        //    if (context.interaction is HoldInteraction)
        //    {
        //        HoldAbility();
        //    }
        //    else if (context.interaction is TapInteraction)
        //    {
        //        ApplyForce();
        //    }
        //};

        //_controls.Player.Player3.performed += context =>
        //{
        //    if (context.interaction is HoldInteraction)
        //    {
        //        HoldAbility();
        //    }
        //    else if (context.interaction is TapInteraction)
        //    {
        //        ApplyForce();
        //    }
        //};

        //_controls.Player.Player4.performed += context =>
        //{
        //    if (context.interaction is HoldInteraction)
        //    {
        //        HoldAbility();
        //    }
        //    else if (context.interaction is TapInteraction)
        //    {
        //        ApplyForce();
        //    }
        //};







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
        Debug.Log("HELD");
        _isHeld = true;
        this.transform.Rotate(0,0,0);
        _rb.velocity = Vector3.zero;
        // stop rotation
    }

    private void HoldRelease()
    {
        // use item 

        _isHeld = false;
        
    }

    private void TapRelease()
    {
        // wait float seconds
        // continue rotations
        _isTap = false;
        this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
    }
    private void ApplyForce()
    {
        Debug.Log("Apply FORCE");
        _isTap = true;
        this.transform.Rotate(0, 0, 0);
        _rb.AddForce(transform.right * Force, ForceMode2D.Impulse);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Player is always rotating in a fixed position

        if (_isHeld != true || _isTap != true)
        {
            Debug.Log("Rotating in fixed position");

            this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
        }
        

    }

    private void Update()
    {

        if (_controls.Player.Player1.IsPressed())
        {
            ApplyForce();
        }
        if (_controls.Player.Player1.WasPressedThisFrame())
        {
            _holdDuration += Time.deltaTime;
            if (_holdDuration >= 0.5f)
            {
                _isHeld = true;
                HoldAbility();
            }

        }
        else if (_controls.Player.Player1.WasReleasedThisFrame())
        {
            Debug.Log("Input is canceled");
            _holdDuration = 0;

            if (_isHeld == true && _hasItem)
            {
                HoldRelease();
            }
            else if (_isTap)
            {
                _isTap = false;
                this._rb.velocity = Vector3.zero;
            }
        }
    }
}
