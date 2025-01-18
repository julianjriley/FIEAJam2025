using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class RollerCoasterManager : MonoBehaviour
{
    public SplineContainer[] Splines;
    public Object[] Coaster1;
    public Object[] Coaster2;

    private int counter = 0;
    public float TimeBetweenCars;
    public float StartDelay;
    public float Interval;
    public Transform[] HazardSpawns;
    public Object HazardSign;
    public float TrainDelay;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(2, 2, true);
        InvokeRepeating("DecideSpawnLogic", StartDelay, Interval);
    }

    /*void Test() {
        GameObject _temp = (GameObject) Instantiate(test);
        _temp.GetComponent<SplineAnimate>().m_Target = Splines[0];
    }*/

    void DecideSpawnLogic() {
        int _rand = Random.Range(1, 4);
        //50% chance to spawn a coaster at this interval
        if (_rand == 1 || _rand == 2) {
            DecideCoasterLogic();
        }
    }
    void DecideCoasterLogic() {
        Debug.Log("DecideCoasterLogic");
        int _numCoasterCars = Random.Range(10, 15);
        int _rand = Random.Range(0, 2);
        HandleHazardSymbol(_rand);
        StartCoroutine(SpawnCoaster(_numCoasterCars, _rand));
    }

    void HandleHazardSymbol(int _coasterChoice) {
        Vector3 _spawnPos = Vector3.zero;
        if (_coasterChoice == 0) {
            _spawnPos = HazardSpawns[0].position;
        } else if (_coasterChoice == 1) {
            _spawnPos = HazardSpawns[1].position;
        }
        Instantiate(HazardSign, _spawnPos, Quaternion.identity);
    }

    IEnumerator SpawnCoaster(int _numCoasterCars, int _coasterChoice) {
        yield return new WaitForSeconds(TrainDelay);
        while (counter < _numCoasterCars) {
            SpawnCoasterPiece(counter, _coasterChoice);
            yield return new WaitForSeconds(TimeBetweenCars);
            counter++;
        }
        Debug.Log("SpawnCoaster ends");
        counter = 0;
    }

    void SpawnCoasterPiece(int _index, int _coasterChoice) {
        GameObject _temp = null;
        if (_coasterChoice == 0) {
            if (_index == 0) {
                _temp = (GameObject) Instantiate(Coaster1[_index]);
            } else if (_index % 2 == 0) {
                _temp = (GameObject) Instantiate(Coaster1[2]);
            } else {
                _temp = (GameObject) Instantiate(Coaster1[1]);
            }
        } else if (_coasterChoice == 1) {
            if (_index == 0) {
                _temp = (GameObject) Instantiate(Coaster2[_index]);
            } else if (_index % 2 == 0) {
                _temp = (GameObject) Instantiate(Coaster2[2]);
            } else {
                _temp = (GameObject) Instantiate(Coaster2[1]);
            }
        }
        _temp.GetComponent<SplineAnimate>().m_Target = Splines[_coasterChoice];
    }
}
