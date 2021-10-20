using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private float playerSpeed = 10f;

    private float horizontalAxis;
    private float verticalAxis;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetAxis();
    }

    private void FixedUpdate()
    {
        MoveTo();
    }

    // menggerakkan pemain ke arah vector (1,1)
    private void MoveTo()
    {
        Vector2 playerMovement = new Vector2(horizontalAxis, verticalAxis);

        playerRigidbody.velocity = playerMovement * playerSpeed;
    }

    private void GetAxis()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        
        Debug.Log(horizontalAxis + "," + verticalAxis);
    }
}
