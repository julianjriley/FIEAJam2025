using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour
{
    // get list of item scriptable objects
    // randomly pick a point on the map to spawn from an array of points
    // make shadow appear as anticipation
    // instantiate balloon, but assign it a random S.O. from a list
    // make items start w/ 50 opacity then increase as it comes closer to the ground

    [SerializeField]
    private UsableItemBase _item;

    public UsableItemBase Balloon;
    public List<Transform> SpawnpointList;
    public List<UsableItemBase> ItemsList;

    private int _spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _item = ItemsList[UnityEngine.Random.Range(0, 6)];

        InvokeRepeating("DropItem", 2.0f, 1.8f);
    }

    void DropItem()
    {
        _spawnPoint = UnityEngine.Random.Range(1, 6);
        Balloon.gameObject.transform.position = SpawnpointList[_spawnPoint].position;
        Instantiate(Balloon);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
