using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class ZAxisObstacle : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 moveDirection = Vector3.forward;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("Z obstacle hit wall: " + collision.collider.name);
            moveDirection = -moveDirection; // Reverse direction on wall hit
        }

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player hit by Z obstacle. Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
