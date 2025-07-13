using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int totalCollectibles;
    private int collectedCount = 0;

    public string[] levelNames; // Set in Inspector: ["Level1", "Level2", "Level3"]

    void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void AddCollectible()
    {
        collectedCount++;

        if (collectedCount >= totalCollectibles)
        {
            Debug.Log("All collectibles collected!");

            // Get current scene name
            string currentScene = SceneManager.GetActiveScene().name;

            // Find index of current scene
            int currentIndex = System.Array.IndexOf(levelNames, currentScene);

            // If there’s a next level, load it
            if (currentIndex >= 0 && currentIndex < levelNames.Length - 1)
            {
                string nextScene = levelNames[currentIndex + 1];
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Debug.Log("Last level reached. Loading win screen...");
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
