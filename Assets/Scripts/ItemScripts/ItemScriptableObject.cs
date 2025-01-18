using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject itemPrefab;

    //this function is to be called by the player when accessing/instantiating held item
    public GameObject GetUsableItem()
    {
        return itemPrefab;
    }
    
}
