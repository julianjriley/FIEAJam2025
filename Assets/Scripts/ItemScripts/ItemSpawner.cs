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

    public GameObject Balloon;
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
        Balloon.transform.position = SpawnpointList[_spawnPoint].position;
        Instantiate(Balloon);

        // INTERPOLATE size change
        Balloon.transform.localScale = new Vector2(.5f, .5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            // when bumper collides with balloon
            Destroy(Balloon);
            // TODO BELOW: set the bumper's item to the balloon 
            // other.gameObject.GetComponent<PlayerMovement>().item = Balloon

            // TODO: Write CopyItem function in PlayerMovement so that the bumpers deal w the item in that script
            // other.gameObject.GetComponent<PlayerMovement>().CopyItem; 


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
