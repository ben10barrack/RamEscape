using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene control

public class PlayerHitReset : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit by enemy. Restarting...");

            // Restart current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
