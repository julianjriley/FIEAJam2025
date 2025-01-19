using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor.UIElements;
using UnityEngine;

public class PopAndScale : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector2 startingPosition;
    Vector2 endPosition;
    Vector2 direction;
    float distance;

    float distanceFloat;

    float distanceProgress = 0;

    bool landed = false;

    float slideDistance;

    float rotationSpeed;
    private void Start()
    {
        startingPosition = transform.position;
        rotationSpeed = Random.Range(1f, 2f) * 80f * (Random.Range(0,2)*2-1);
        AssignPopValues(Random.Range(0.3f,3f), new Vector2(Random.Range(-1,1f), Random.Range(-1, 1f)).normalized);
        //AssignPopValues(2, new Vector2(1, 1).normalized);
    }
    
    public void AssignPopValues(float _distance, Vector2 _direction)
    {
        direction = _direction;
        distance = _distance;
        endPosition = startingPosition + (direction * distance);
    }

    private void Update()
    {
        if(!landed)
            transform.position = Vector2.Lerp(startingPosition, endPosition, distanceProgress);
        if (distanceProgress < 0.5f)
            distanceProgress += Time.deltaTime * 2.5f;
        else
            distanceProgress += Time.deltaTime /1.5f;
        UpdateScaleAndSprite();
        if (landed)
        {
            slideDistance += Time.deltaTime * 1.3f;
            SlideAtTheEnd();
        }
        transform.Rotate(new Vector3(0,0,rotationSpeed * Time.deltaTime));
        if (slideDistance > 1 && rotationSpeed > 0)
            rotationSpeed = Mathf.Clamp(rotationSpeed - Time.deltaTime * 20, 0, 100);
        else if(slideDistance > 1 && rotationSpeed < 0)
        {
            //Debug.Log("spinning");
            rotationSpeed = Mathf.Clamp(rotationSpeed + Time.deltaTime * 20, -100, 0);
        }
            
        
            
    }

    void UpdateScaleAndSprite()
    {
        if (landed)
            return;
        if (distanceProgress > 1)
        {
            landed = true;
            rotationSpeed /= 2;
            return;
        }
            
        float scalingFactor = Unity.Mathematics.math.remap(0f, 0.5f, 1f, 0f,Mathf.Abs(distanceProgress - 0.5f));
        Color tempColor = spriteRenderer.color;
        tempColor.a = 1 - scalingFactor;
        spriteRenderer.color = tempColor;

        transform.localScale = new Vector2(1 + scalingFactor, 1 + scalingFactor);
        
    }

    void SlideAtTheEnd()
    {
        transform.position = Vector2.Lerp(endPosition, endPosition + (direction * 0.8f), slideDistance);

        
    }
}
