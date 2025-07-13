using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class VerticalObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float maxHeight = 1.5f;

    private Rigidbody rb;
    private Vector3 startPos;
    private Vector3 moveDirection = Vector3.up;

    void Start()
    {
        startPos = transform.position;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    void FixedUpdate()
    {
        // Check if max height reached
        if (transform.position.y >= startPos.y + maxHeight && moveDirection == Vector3.up)
        {
            moveDirection = Vector3.down;
        }

        rb.linearVelocity = moveDirection * speed;  // ✅ Fixed: velocity instead of linearVelocity
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor") && moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up; // Bounce up again
        }

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player hit vertical obstacle. Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
