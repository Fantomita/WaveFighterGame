using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();  // Adjusts the sprite direction
        Move(); // Moves the player
    }

    private void PlayerInput()
    {
        // Capture movement input from the player
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        // Pass movement values to the animator for animation purposes
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        // Move the player based on input
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        /*Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }*/

        if (movement.x < 0) // Moving left
        {
            mySpriteRenderer.flipX = true; // Flip the sprite
        }
        else if (movement.x > 0) // Moving right
        {
            mySpriteRenderer.flipX = false; // Ensure sprite is not flipped
        }
    }
}
    