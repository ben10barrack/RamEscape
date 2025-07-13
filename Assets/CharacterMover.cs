using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Get input
        float h = Input.GetAxis("Horizontal"); // A/D (left/right)
        float v = Input.GetAxis("Vertical");   // W/S (forward/backward)

        // Move forward/backward based on current facing direction
        Vector3 moveDirection = transform.forward * v;
        Vector3 moveVelocity = moveDirection * moveSpeed;
        moveVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = moveVelocity;

        // Rotate left/right (A/D) around Y-axis
        if (h != 0f)
        {
            float turn = h * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // Animate based on speed
        float movementAmount = Mathf.Abs(v);
        animator.SetFloat("Speed", movementAmount);
    }
}
