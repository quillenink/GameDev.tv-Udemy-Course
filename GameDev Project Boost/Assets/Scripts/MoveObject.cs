using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Vector3 moveVector;
    [SerializeField] float period = 2f;
    
    Vector3 startPosition;
    float moveFactor;

    void Start() 
    {
        startPosition = transform.position;
    }

    void Update() 
    {
        if(period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continually growing over time
        const float tau = Mathf.PI * 2; // 6.283, # of radians to make full circle
        float rawSinWave = Mathf.Sin( cycles * tau); // -1 to 1

        moveFactor = (rawSinWave + 1f) / 2f; // 0 to 1

        Vector3 offset = moveVector * moveFactor;
        transform.position = startPosition + offset;
    }

}
