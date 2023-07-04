using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float fallWaitTime = 3f;
    public bool hasSwitch;
    Rigidbody rigidBody;
    MeshRenderer meshRenderer;
    bool countdown;
    float startTime;

    private void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        meshRenderer = this.GetComponent<MeshRenderer>();
        rigidBody.useGravity = false;
        meshRenderer.enabled = false;
        if(!hasSwitch)
        {
            CountdownStart();
        }
    }

    private void Update() 
    {
        if(Time.time >= fallWaitTime + startTime && countdown)
        {
            rigidBody.useGravity = true;
            meshRenderer.enabled = true;
        }
    }
    
    public void CountdownStart()
    {
        countdown = true;
        startTime = Time.time;
    }
}
