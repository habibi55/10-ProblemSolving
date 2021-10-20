using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private float playerSpeed = 10f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveTo();
    }

    // menggerakkan pemain ke arah vector (1,1)
    private void MoveTo()
    {
        Vector2 velocity = Vector2.one * playerSpeed;
        Debug.Log(velocity.magnitude);
        playerRigidbody.velocity = velocity;
    }
}
