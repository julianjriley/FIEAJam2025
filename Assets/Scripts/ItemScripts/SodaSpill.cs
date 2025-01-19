using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaSpill : MonoBehaviour
{
    GameObject owningPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owningPlayer)
            return;
        //TODO: Slow down player
    }

    public void AssignOriginalPlayer(GameObject player)
    {
        owningPlayer = player;
    }
}
