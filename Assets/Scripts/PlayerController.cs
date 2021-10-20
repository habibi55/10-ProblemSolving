using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private float playerSpeed = 10f;
    private bool isLaunched = false;

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
        if (isLaunched)
        {
            return;
        }

        float yDirection = Random.Range(-1.01f, 1.01f);
        Vector2 velocity = new Vector2(1f, yDirection) * playerSpeed;
        
        playerRigidbody.AddForce(velocity, ForceMode2D.Impulse);

        isLaunched = true;
    }
}
