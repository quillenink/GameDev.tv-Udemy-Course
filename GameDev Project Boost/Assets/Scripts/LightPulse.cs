using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{

    public float pulseSpeed, pulseIntensity, jitter;
    public Vector2 jitterFrequencyRange;

    bool isGrowing = false, timeToJitter;
    float baseIntensity, jitterCounter = 0.2f;
    Light lightComp;

    void Start()
    {
        lightComp = GetComponent<Light>();
        baseIntensity = lightComp.intensity;
    }

    void Update()
    {
        if(!isGrowing)
        {
            lightComp.intensity -= pulseSpeed * Time.deltaTime;
        }
        else if(isGrowing)
        {
            lightComp.intensity += pulseSpeed * Time.deltaTime;
        }
        if(lightComp.intensity >= baseIntensity + pulseIntensity || lightComp.intensity <= baseIntensity - pulseIntensity)
        {
            isGrowing = !isGrowing;
        }

        if(jitter != 0f && timeToJitter)
        {
            StartCoroutine(JitterEffect());
            timeToJitter = false;
            jitterCounter = 1000f;
        }
        else if(jitter != 0f && !timeToJitter)
        {
            jitterCounter -= Time.deltaTime;
            if(jitterCounter <= 0f)
            {
                timeToJitter = true;
            }
        }
    }

    IEnumerator JitterEffect()
    {
        //Debug.Log("Begin jitter!");
        float amount = Random.Range(-jitter, jitter);
        lightComp.intensity += amount;
        yield return new WaitForSeconds(Random.Range(0.01f, 0.3f));
        lightComp.intensity -= amount;
        jitterCounter = Random.Range(jitterFrequencyRange.x, jitterFrequencyRange.y);
    }
}
