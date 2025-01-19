using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ItemSpawner : MonoBehaviour
{
    // randomly pick a point on the map to spawn from an array of points
    // make shadow appear as anticipation

    int counter = 0;
    public Canvas Canvas;
    public GameObject BalloonPrefab;
    public GameObject Shadow;
    public GameObject VomitPrefab;
    public List<Transform> SpawnpointList;

    [SerializeField]
    private List<int> _freeSpots;

    private int _spawnPoint;
    private int _vomitSpawnPoint;

    private int _vomCounter = 0;

    private void Start()
    {
        Balloon.BalloonPickedUp += SubtractToCounter;
        Vomit.VomHit += SubtractToVomCounter;

        Invoke("DropItem", 2f);
    }

    void DropVomit()
    {
        if (_vomCounter >= 2)
        {
            return;
        }
        _vomitSpawnPoint = UnityEngine.Random.Range(0, 5);

        if (_vomitSpawnPoint == _spawnPoint)
        {
            return;
        }

       

        if (_freeSpots[_vomitSpawnPoint] == 0)
        {
            //GameObject theVomit = Instantiate(VomitPrefab);
            //theVomit.transform.position = SpawnpointList[_vomitSpawnPoint].position;
            //theVomit.SetActive(true);

            //_freeSpots[_vomitSpawnPoint] = 1;

            //StartCoroutine(SpawnVom(theVomit));
        }
    }
    IEnumerator SpawnVom(GameObject theVomit)
    {
        yield return new WaitForSeconds(0.8f);
        //DropVomit();
    }

    void DropItem()
    {
       

        if (counter >= 3)
        {
            return;
        }
        else
        {
            //Invoke("DropVomit", 3f);
        }
        // Assign the shadow to a random position to start from

        _spawnPoint = UnityEngine.Random.Range(0, 5);

        // SHADOW anticipation starts below !!       
        

        if (_freeSpots[_spawnPoint] == 0)
        {
            GameObject theShadow = Instantiate(Shadow);
            theShadow.transform.position = SpawnpointList[_spawnPoint].position;
            theShadow.SetActive(true);

            _freeSpots[_spawnPoint] = 1;
            counter++;

            // LERP to a random end position
            StartCoroutine(SpawnMore(theShadow));
        }
        else
        {
            return;
        }
    }

    IEnumerator SpawnMore(GameObject theShadow)
    {
        yield return new WaitForSeconds(0.8f);

        GameObject theBalloon = Instantiate(BalloonPrefab);
        theBalloon.transform.position = theShadow.transform.position;

        theBalloon.GetComponent<Balloon>().SetShadow(theShadow);

        yield return new WaitForSeconds(2.4f);
        DropItem();
    }

    void SubtractToCounter()
    {
        _freeSpots[_spawnPoint] = 0;
        counter--;
    }

    void SubtractToVomCounter()
    {
        _freeSpots[_vomitSpawnPoint] = 0;
        _vomCounter--;
    }


}
