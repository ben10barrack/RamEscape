using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy self when hitting a wall
        }

        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject); // Optional: also destroy if it hits the player
        }
    }
}
