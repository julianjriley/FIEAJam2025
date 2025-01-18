using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItemBase : MonoBehaviour
{
    private GameObject owningPlayer;

    //This function is called by any of the players after they instantiate their held item.
    public virtual void UseItem(GameObject player)
    {
        owningPlayer = player;
        UseItemFunctionality();
    }

    //Override this function when creating each item's specific effect
    protected virtual void UseItemFunctionality()
    {

    }

    
}
