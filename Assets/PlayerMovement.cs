using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UIElements;

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

    [SerializeField]
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
        _controls.Player.Player1.performed += context =>
        {
            if (context.interaction is TapInteraction)
            {
                Debug.Log("TAP performed");
                Tap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Debug.Log("HOLD performed");
                Hold(context);
            }


            // HOW TO CANCEL AND DIFFERENTIATE BETWEEN TAP HOLD ?
            
            //_controls.Player.Player1.canceled += HoldRelease;
        };


    }

    private void Tap(InputAction.CallbackContext context)
    {
        // Apply force
        Debug.Log("TAP called");
        Debug.Log(_rb.name);
        _isTap = true;
        Vector2 test = new Vector2(transform.right.x, transform.right.y);
        _rb.AddForce(test* Force, ForceMode2D.Impulse);

        Debug.Log("Force applied: " + test * Force);
        
    }

    private void TapRelease()
    {
        // Player should start rotating again
        Debug.Log("TAP is RELEASED");

        _rb.AddForce(transform.right * Force, ForceMode2D.Impulse);
        _rb.velocity = Vector3.zero;
        _isTap = false;

    }

    private void MultiTap(InputAction.CallbackContext context)
    {
        // Stop spinning out of control
    }

    private void Hold(InputAction.CallbackContext context)
    {
        // Stop rotation
        Debug.Log("HOLD called");

        _isHeld = true;
        this.transform.Rotate(0, 0, 0);
        _rb.velocity = Vector3.zero;
    }
    private void HoldRelease()
    {
        // Move forward
        Debug.Log("HOLD is RELEASED");

        _isHeld = false;
        _rb.velocity = Vector3.zero;

    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Player is always rotating in a fixed position

        if (_isHeld != true && _isTap != true)
        {
            Debug.Log("Rotating in fixed position");

            this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
        }
        

    }

    private void Update()
    {

        if (_controls.Player.Player1.WasReleasedThisFrame())
        {
            Debug.Log("Input is canceled");

            if (_isHeld == true)
            {
                HoldRelease();

                if (_hasItem)
                {
                    // activate stuff
                }
            }
            else if (_isTap)
            {
                TapRelease();
            }
        }
    }
}
