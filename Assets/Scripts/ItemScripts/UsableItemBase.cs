using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItemBase : MonoBehaviour
{
    protected GameObject owningPlayer;
    protected Vector2 facingDirection;
    //This function is called by any of the players after they instantiate their held item.
    public virtual void UseItem(GameObject player, Vector2 direction)
    {
        owningPlayer = player;
        facingDirection = direction;
        UseItemFunctionality();
    }

    //Override this function when creating each item's specific effect
    protected virtual void UseItemFunctionality()
    {

    }





}
