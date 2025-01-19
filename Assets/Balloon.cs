using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private Animator _anim;
    private UsableItemBase _item;
    public List<UsableItemBase> ItemsList;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _item = ItemsList[UnityEngine.Random.Range(0, 6)];
    }


    private void OnEnable()
    {
        _anim.Play("Balloon");
    }
}
