using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private PlayerInput playerInput;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 5f;
    [SerializeField] private float interactRadius; // Jarak jangkauan interaksi player
    public bool CanMove { get; set; } = true;
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += ctx => movement = Vector2.zero;
        playerInput.Player.Interact.performed += ctx => Interact();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    private void Interact()
    {
        // abaikan input tombol interaksi agar tidak memicu dialog ganda atau tumpang tindih.
        if (!CanMove) return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRadius);

        foreach (Collider2D collider in colliders)
        {
            // Cek apakah Game Object yang terkena lingkaran memiliki kontrak IInteractable
            Interactable interactableObject = collider.GetComponent<Interactable>();

            if (interactableObject != null)
            {
                // (interface interact untuk objek yang mempunyai script nya)
                interactableObject.Interact();

                break; 
            }
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = playerInput.Player.Move.ReadValue<Vector2>();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(
            rb.position +
            movement * moveSpeed * Time.fixedDeltaTime
        );
    }

    private void UpdateAnimation()
    {
        animator.SetBool("IsMoving", movement != Vector2.zero);
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualisasi jangkauan interaksi di Scene View
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }

}
