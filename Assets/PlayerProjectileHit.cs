using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProjectileHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Hit by projectile. Restarting level...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
