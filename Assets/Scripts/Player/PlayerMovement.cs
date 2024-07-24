using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables de acceso publico para pwpups
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    private Rigidbody2D rb;

    [Header("Drag")]
    [SerializeField] private float gravityMultiplier;

    [Header("Rotation")]
    [SerializeField] private Transform visualTransform;

    [Header("Inputs")]
    private Vector2 inputVector;
    private float xInput;

    [Header("Animations")]
    private Animator animator;

    [Header("GroundCheck")]
    [SerializeField] private float extraRayHeight;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        Inputs();
        IsGrounded();
        Movement();
        Animations();
    }

    private void FixedUpdate()
    {
        GravityCompensation();
    }

    private void Inputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        inputVector = new Vector2(xInput, 0f);

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            Jump();
    }

    private void Movement()
    {
        if (Mathf.Abs(inputVector.x) > 0)
        {
            transform.Translate(moveSpeed * Time.deltaTime * inputVector);
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void GravityCompensation()
    {
        if (!PlayerGroundCheck.IsGrounded)
            rb.AddForce(Vector2.down * gravityMultiplier, ForceMode2D.Force);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraRayHeight, groundLayer);
        
        return raycastHit.collider != null;
    }

    private void Animations()
    {
        int yDirection;

        if (rb.velocity.y > 0f)
            yDirection = 1;
        else if (rb.velocity.y < 0f)
            yDirection = -1;
        else
            yDirection = 0;

        animator.SetFloat("xValue", Mathf.Abs(inputVector.x));
        animator.SetInteger("yValue", yDirection);

        if (rb.velocity.y != 0f)
            animator.SetLayerWeight(1, 1);
        else
            animator.SetLayerWeight(1, 0);

        if (inputVector.x != 0f)
            transform.localScale = new Vector3(inputVector.x, 1f, 1f);
    }
}
