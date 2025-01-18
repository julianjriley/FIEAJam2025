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
    // Start is called before the first frame update
    void Start()
    {
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
        int _numCoasterCars = Random.Range(7, 12);
        int _rand = Random.Range(0, 2);
        StartCoroutine(SpawnCoaster(_numCoasterCars, _rand));
    }

    IEnumerator SpawnCoaster(int _numCoasterCars, int _coasterChoice) {
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
