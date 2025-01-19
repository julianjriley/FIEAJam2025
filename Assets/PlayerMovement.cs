using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    private PlayerMovement _playerMovement;
    private Rigidbody2D _rb;
    private float _playerVelocity;

    public float ZRotation;
    public float Force;
    [SerializeField]
    private int _player;
    [SerializeField]
    private float _higherSpeed;

    public bool _hasControl = true;
    private bool _isHeld = false;
    private bool _isTap = false;
    
    private bool _hasItem = false;
    private PlayerControls _controls;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _controls = new PlayerControls();
       
        
        switch(_player)
        {
            case 1:
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

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(_rb.name);
    }

    private void OnEnable()
    {
        _controls.Player.Player1.started += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                Tap(context);
            }
        };
        _controls.Player.Player1.performed += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                Debug.Log("MULTITAP performed");
                MultiTap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Debug.Log("HOLD performed");
                Hold(context);
            }
        };

        _controls.Player.Player2.started += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                Tap(context);
            }
        };

        _controls.Player.Player2.performed += context =>
        {

            if (context.interaction is MultiTapInteraction)
            {
                MultiTap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };

        _controls.Player.Player3.started += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                Tap(context);
            }
        };

        _controls.Player.Player3.performed += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                MultiTap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };

        _controls.Player.Player4.started += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                Tap(context);
            }
        };

        _controls.Player.Player4.performed += context =>
        {
            if (context.interaction is MultiTapInteraction)
            {
                MultiTap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };
    }

    private void Tap(InputAction.CallbackContext context)
    {
        if(_hasControl == false)
        {
            return; 
        }

        Debug.Log("TAP called");

        _isTap = true;

        //this.transform.Rotate(0, 0, 0);
        Vector2 test = new Vector2(transform.right.x, transform.right.y);
        _rb.AddForce(test* Force, ForceMode2D.Impulse);        
    }

    private void TapRelease()
    {
        // Player should start rotating again
        Debug.Log("TAP is RELEASED");

        _isTap = false;

    }

    private void MultiTap(InputAction.CallbackContext context)
    {
        Debug.Log("MULTITAP called");

        // Stop spinning out of control
        _hasControl = true;


        //_rb.velocity = Vector3.zero;
    }

    private void Hold(InputAction.CallbackContext context)
    {
        if (_hasControl == false)
        {
            return;
        }
        // Stop rotation
        Debug.Log("HOLD called");
        Debug.Log("bumper: " + _rb.name);

        _isHeld = true;

        //this.transform.Rotate(0, 0, 0);
        _rb.velocity = Vector3.zero;
    }
    private void HoldRelease()
    {
        // Move forward
        Debug.Log("HOLD is RELEASED");

        _isHeld = false;
        _rb.velocity = Vector3.zero;

    }

    private void FixedUpdate()
    {
        // Player is always rotating in a fixed position

        if(_controls.Player.Player1.IsPressed() == false && _player == 1)
        {
            this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
        }
        if (_controls.Player.Player2.IsPressed() == false && _player == 2)
        {
            this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
        }
        if (_controls.Player.Player3.IsPressed() == false && _player == 3)
        {
            this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
        }
        if (_controls.Player.Player4.IsPressed() == false && _player == 4)
        {
            this.transform.Rotate(Vector3.forward * ZRotation * Time.deltaTime);
        }
    }

    private void Update()
    {

        if(_hasControl == false)
        {
            this.transform.Rotate(Vector3.forward * _higherSpeed * Time.deltaTime);
            return;
        }

        if (_controls.Player.Player1.WasReleasedThisFrame())
        {
            if (_isHeld == true)
            {
                HoldRelease();

                if (_hasItem) // need to add check if item != null
                {
                    // activate stuff
                }
            }
            else if (_isTap)
            {
                TapRelease();
            }
        }
        if (_controls.Player.Player2.WasReleasedThisFrame())
        {
            if (_isHeld == true)
            {
                HoldRelease();

                if (_hasItem) // need to add check if item != null
                {
                    // activate stuff
                }
            }
            else if (_isTap)
            {
                TapRelease();
            }
        }
        if (_controls.Player.Player3.WasReleasedThisFrame())
        {
            if (_isHeld == true)
            {
                HoldRelease();

                if (_hasItem) // need to add check if item != null
                {
                    // activate stuff
                }
            }
            else if (_isTap)
            {
                TapRelease();
            }
        }
        if (_controls.Player.Player4.WasReleasedThisFrame())
        {
            if (_isHeld == true)
            {
                HoldRelease();

                if (_hasItem) // need to add check if item != null
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            // When colliding with other players
            // make them spin out

            other.gameObject.GetComponent<PlayerMovement>()._hasControl = false;
            
        }

    }
}
