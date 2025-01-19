using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    int popcorn = 0;
    [SerializeField] GameObject popcornObject;
    [SerializeField] SpriteRenderer popcornSpriteRenderer;
    [SerializeField] Sprite[] popcornLevelSprites;

    int popcornSpriteIndex = 0;

    public void UpdateSprite(int amountOfPopcorn)
    {
        
    }

    public void AddToScore()
    {
        popcorn += 1;
    }

    //Call this when spinning out
    public void LosePopcorn()
    {
        if (popcorn <= 0)
            return;
        int amountLost = popcorn / 4;
        for (int i = 0; i < amountLost; i++)
        {
            Instantiate(popcornObject, gameObject.transform.position, Quaternion.identity);
        }
        popcorn -= amountLost;
        InvokeRepeating("BleedPopcorn", 0.2f, 0.35f);
    }

    //Call this when regaining composure
    public void StopTheBleeding()
    {
        CancelInvoke();
    }
    void BleedPopcorn()
    {
        if(popcorn > 0)
        {
            Instantiate(popcornObject, transform.position, Quaternion.identity);
        }
    }

    void DeterminePopcornLevel(int amountOfPopcorn)
    {
        if(amountOfPopcorn <= 5)
        {
            popcornSpriteIndex = 0;
        }
    }
}
