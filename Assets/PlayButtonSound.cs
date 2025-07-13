using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSound : MonoBehaviour
{
    public AudioClip clickSound;        // Your click sound
    private AudioSource audioSource;    // Reference to AudioSource

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();  // Finds AudioSource in Canvas
        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
