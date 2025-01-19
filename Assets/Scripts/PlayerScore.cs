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

    public void UpdateSprite(int popcornSpriteIndex)
    {
        popcornSpriteRenderer.sprite = popcornLevelSprites[popcornSpriteIndex];
    }

    public void AddToScore()
    {
        popcorn += 1;
        UpdateSprite(popcornSpriteIndex);
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
        UpdateSprite(popcorn);
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
        UpdateSprite(popcorn);
    }
    private void Update()
    {
        DeterminePopcornLevel(popcorn);
    }

    void DeterminePopcornLevel(int amountOfPopcorn)
    {
        if(amountOfPopcorn > 59)
        {
            popcornSpriteIndex = 4;
        }
        if(amountOfPopcorn > 34)
        {
            popcornSpriteIndex = 3;
        }
        if(amountOfPopcorn > 14)
        {
            popcornSpriteIndex = 2;
        }
        if(amountOfPopcorn > 4)
        {
            popcornSpriteIndex = 1;
        }
        if(amountOfPopcorn > -1)
        {
            popcornSpriteIndex = 0;
        }
    }
}
