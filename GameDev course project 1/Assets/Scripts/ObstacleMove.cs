using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Transform moveToPoint;
    public float moveSpeed = 2f;

    Vector3 start, end;
    float moveCounter;

    private void Start() 
    {
        start = transform.position;
        end = moveToPoint.position;
        moveCounter = 0f;
    }

    //this script doesn't work, it needs a bool to track going up and down
    void Update()
    {
        
        Vector3 moveTo = Vector3.Lerp(start, end, moveCounter);
        transform.Translate(moveTo);
        if(moveCounter < 1f)
        {
            moveCounter += Time.deltaTime * moveSpeed;
            if(moveCounter > 1f)
            {
                moveCounter = 1f;
            }
        }
        if(moveCounter >= 1f)
        {
            moveCounter -= Time.deltaTime * moveSpeed;
        }   

    }
}
