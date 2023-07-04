using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float jumpHeight;

    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        if(moveH == 0f && moveV == 0f)
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);
        }
        MovePlayer(moveH, moveV);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity += new Vector3(0, jumpHeight, 0);
        }
    }

    void MovePlayer(float moveHori, float moveVert)
    {
        float xValue = moveHori * Time.deltaTime * moveSpeed;
        float zValue = moveVert * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0f, zValue);
    }

}
