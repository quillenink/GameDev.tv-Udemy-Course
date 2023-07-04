using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //PARAMETERS
    //CACHE
    //STATE
    public float thrustMultiplier, rotationMultiplier;
    [SerializeField] ParticleSystem thrustParticle, aRotateParticle, dRotateParticle;
    [SerializeField] AudioSource rotateSound;

    AudioSource thrustSound;
    Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
    }

    void Update() 
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(0, 10 * thrustMultiplier * Time.deltaTime, 0);
        if (!thrustSound.isPlaying)
        {
            thrustSound.Play();
        }
        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }
    }

    void StopThrusting()
    {
        thrustSound.Stop();
        thrustParticle.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationMultiplier);
        if (!aRotateParticle.isPlaying)
        {
            aRotateParticle.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationMultiplier);
        if (!dRotateParticle.isPlaying)
        {
            dRotateParticle.Play();
        }
    }

    void StopRotating()
    {
        aRotateParticle.Stop();
        dRotateParticle.Stop();
        rotateSound.Stop();
    }

    void ApplyRotation(float rotation)
    {
        if (!rotateSound.isPlaying)
        {
            rotateSound.Play();
        }
        rb.freezeRotation = true;
        transform.Rotate(0, 0, rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
