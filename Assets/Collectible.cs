using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            ScoreManager.Instance.AddScore(1);

            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            if (levelManager != null)
            {
                levelManager.AddCollectible();
            }
        }
    }
}
