using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : MonoBehaviour
{
    public GameObject[] objectsToSwitch;

    private void Start()
    {
        foreach(GameObject obj in objectsToSwitch)
            {
                obj.SetActive(false);
            }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(GameObject obj in objectsToSwitch)
            {
                obj.SetActive(true);
                obj.GetComponent<Dropper>().CountdownStart();
            }
        }
    } 
}
