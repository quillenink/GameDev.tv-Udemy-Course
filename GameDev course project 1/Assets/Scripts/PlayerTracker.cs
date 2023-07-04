using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = FindObjectOfType<Mover>().gameObject;
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
}
