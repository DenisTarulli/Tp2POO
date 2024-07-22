using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables de acceso publico para pwpups
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;

    [Header("Drag")]
    [SerializeField] private float gravityMultiplier;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float angle;

    [Header("Rotation")]
    [SerializeField] private Transform visualTransform;

    [Header("Inputs")]
    private Vector2 inputVector;
    private float xInput;

    [Header("Animations")]
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Inputs();
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

        if (Input.GetKeyDown(KeyCode.W) && PlayerGroundCheck.IsGrounded)
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
        if (PlayerGroundCheck.IsGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void GravityCompensation()
    {
        if (!PlayerGroundCheck.IsGrounded)
            rb.AddForce(Vector2.down * gravityMultiplier, ForceMode2D.Force);
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
