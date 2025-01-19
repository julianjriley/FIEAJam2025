using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        int amountLost = (popcorn / 4) + (popcorn % 4);
        for (int i = 0; i < amountLost; i++)
        {
            GameObject thePopcorn = Instantiate(popcornObject, gameObject.transform.position, Quaternion.identity);
            thePopcorn.GetComponent<PopAndScale>().AssignPopValues(3f, new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f)).normalized);
        }
        popcorn -= amountLost;
        InvokeRepeating("BleedPopcorn", 0.2f, 0.35f);
        UpdateSprite(popcornSpriteIndex);
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
            GameObject thePopcorn = Instantiate(popcornObject, gameObject.transform.position, Quaternion.identity);
            thePopcorn.GetComponent<PopAndScale>().AssignPopValues(3f, new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f)).normalized);
            popcorn -= 1;
        }
        UpdateSprite(popcornSpriteIndex);
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
        else if(amountOfPopcorn > 34)
        {
            popcornSpriteIndex = 3;
        }
        else if(amountOfPopcorn > 14)
        {
            popcornSpriteIndex = 2;
        }
        else if(amountOfPopcorn > 4)
        {
            popcornSpriteIndex = 1;
        }
        else if(amountOfPopcorn > -1)
        {
            popcornSpriteIndex = 0;
        }
    }

    public int GetScore()
    {
        return popcorn;
    }
}
