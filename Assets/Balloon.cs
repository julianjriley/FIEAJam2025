using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Balloon : MonoBehaviour
{
    // get list of item scriptable objects

    public static event Action BalloonPickedUp;

    GameObject ShadowObj;

    private Animator _anim;
    private ItemScriptableObject _item;

    public List<GameObject> ItemsList;
    [SerializeField]
    private float _height;
    [SerializeField]
    private float _speed;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _item = ItemsList[UnityEngine.Random.Range(0, 3)].GetComponent<ItemScriptableObject>();
        _anim.Play("Balloon");
        
    }

    public void SetShadow(GameObject obj)
    {
        ShadowObj = obj;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            BalloonPickedUp?.Invoke();
            Destroy(ShadowObj);
            Destroy(gameObject);

            other.gameObject.GetComponent<PlayerMovement>().Item = _item;

        }
    }
    
}
