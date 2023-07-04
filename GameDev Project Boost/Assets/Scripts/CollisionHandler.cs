using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float loadDelay = 1f;
    [SerializeField] AudioClip crash, win;
    [SerializeField] ParticleSystem crashParticle, winParticle;
    [SerializeField] AudioSource winLoseSounds;
    [SerializeField] bool rocketDebugControls = true;

    bool isTransitioning = false;
    bool ignoreCollision = false;

    void Update() 
    {
        if(rocketDebugControls)
        {
            DebugControls();
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || ignoreCollision) { return; }

        switch(other.gameObject.tag)
        {
            case "Friendly":
                //Debug.Log("Bumped a friendly.");
                break;
            case "Finish":
                WinSequence();
                break;
            case "Fuel":
                Debug.Log("You found some fuel :)");
                break;
            default:
                CrashSequence();
                break;
        }    
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<AudioSource>().Stop();
        crashParticle.Play();
        winLoseSounds.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }
    void WinSequence()
    {
        isTransitioning = true;
        GetComponent<AudioSource>().Stop();
        winParticle.Play();
        winLoseSounds.PlayOneShot(win);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadDelay);
    }

    void DebugControls()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ignoreCollision = !ignoreCollision;
            if (ignoreCollision)
            {
                Debug.Log("Ignore collision on.");
            }
            else { Debug.Log("Ignore collision off."); }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            WinSequence();
        }
    }
    
}
