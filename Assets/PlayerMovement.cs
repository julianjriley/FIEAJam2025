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
    private float _higherSpeed;

    public bool _hasControl = true;
    private bool _isHeld = false;
    private bool _isTap = false;
    
    private bool _hasItem = false;
    private PlayerControls _controls;

    int _tapCount = 0;

    float multiTapThreshold;

    private ItemScriptableObject _heldItem = null;

    private AudioSource _source;
    public AudioClip PlayerHitSound;
    public float MinAttackVelocity;
    public CircleCollider2D FrontCollid;
    public float MinMagnitudeDiff;
    private Queue magnitudeValues = new Queue();
    public float _myVelocity = 0;

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
        _higherSpeed = ZRotation * 3;
        _source = GetComponent<AudioSource>();
        FrontCollid = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {

        _controls.Player.Player1.performed += context =>
        {

            if (context.interaction is TapInteraction)
            {
                Tap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };

        _controls.Player.Player2.performed += context =>
        {

            if (context.interaction is TapInteraction)
            {
                Tap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };

        _controls.Player.Player3.performed += context =>
        {

            if (context.interaction is TapInteraction)
            {
                Tap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };

        _controls.Player.Player4.performed += context =>
        {

            if (context.interaction is TapInteraction)
            {
                Tap(context);
            }
            else if (context.interaction is HoldInteraction)
            {
                Hold(context);
            }
        };

    }

    private void Tap(InputAction.CallbackContext context)
    {
        _tapCount += 1;
        if (_hasControl == false)
        {
            if(_tapCount >= 5)
            {
                Stabilize();
                return;
            }

            multiTapThreshold = 0f;
            return; 
        }
        multiTapThreshold = 0f;
        if (_tapCount > 3)
            SpinOut();


        _isTap = true;

        //this.transform.Rotate(0, 0, 0);
        Vector2 test = new Vector2(transform.right.x, transform.right.y);
        _rb.AddForce(test* Force, ForceMode2D.Impulse);        
    }

    private void TapRelease()
    {
        // Player should start rotating again


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
        magnitudeValues.Enqueue(_rb.velocity.magnitude);
        if (magnitudeValues.Count == 4) {
            magnitudeValues.Dequeue();
        }
        if (!_hasControl)
            return;
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
        multiTapThreshold += Time.deltaTime;
        if (multiTapThreshold >= 0.3f)
        {
            _tapCount = 0;
            multiTapThreshold = 0;
        }

        if (_hasControl == false)
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
        Debug.Log("magnitude of " + gameObject.name + " = " + _rb.velocity.magnitude);
        if (other.gameObject.tag == "Player") {
            GameObject _otherPlayer = other.gameObject;
            if (PlayerHitSound != null) {
                _source.PlayOneShot(PlayerHitSound, 0.3f);
            }
            HandleSpinOuts(_otherPlayer);
        }
    }

    private void HandleSpinOuts(GameObject _hitPlayer) {
        _myVelocity = (float) magnitudeValues.Dequeue();
        float _theirVelocity = _hitPlayer.GetComponent<PlayerMovement>()._myVelocity;
        Debug.Log("my velocity = " + _myVelocity + gameObject.name);
        Debug.Log("their velocity = " + _theirVelocity);
        if (_myVelocity >= MinAttackVelocity) { //|| _rb.linearVelocity.y >= MinAttackVelocity
            //head on collision
            if (FrontCollid.bounds.Contains(_hitPlayer.GetComponent<CircleCollider2D>().bounds.center)) {
                Debug.Log("Head to Head " + gameObject.name);
                if (_myVelocity - _theirVelocity >= MinMagnitudeDiff) {
                    _hitPlayer.GetComponent<PlayerMovement>().SpinOut(Vector2.zero);
                }
            } else if (_myVelocity < _theirVelocity) {
                //Debug.Log("Second Case " + gameObject.name);
                return;
            } else {
                //Debug.Log("Last case " + gameObject.name);
                _hitPlayer.GetComponent<PlayerMovement>().SpinOut(Vector2.zero);
            }
        }
    }
            //other.gameObject.GetComponent<PlayerMovement>()._hasControl = false;

    public void SpinOut(Vector2 pushDirection)
    {
        _hasControl = false;
        _tapCount = 0;
        //TODO: code for push force
    }
    public void SpinOut()
    {
        _hasControl = false;
        _tapCount = 0;
    }

    void Stabilize()
    {
        _hasControl = true;
        _tapCount = 0;
    }
}
