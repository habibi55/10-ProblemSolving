using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private float playerSpeed = 10f;

    private float _horizontalAxis;
    private float _verticalAxis;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetAxis();
        }
    }

    private void FixedUpdate()
    {
        MoveTo();
    }

    // menggerakkan pemain ke arah vector (1,1)
    private void MoveTo()
    {
        Vector2 moveDirection = new Vector2(_horizontalAxis, _verticalAxis);

        _playerRigidbody.position = Vector2.MoveTowards(transform.position, 
            moveDirection, playerSpeed * Time.fixedDeltaTime);
    }

    private void GetAxis()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        _horizontalAxis = currentMousePosition.x;
        _verticalAxis = currentMousePosition.y;
    }

    public void ChangeSize()
    {
        Vector2 playerScale = transform.localScale;
        float addedScale = playerScale.x * 0.015f;
        Vector2 newSize = new Vector2(playerScale.x + addedScale, playerScale.y + addedScale);
            transform.localScale = newSize;
    }
}
