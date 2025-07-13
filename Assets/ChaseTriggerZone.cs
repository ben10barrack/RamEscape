using UnityEngine;

public class ChaseTriggerZone : MonoBehaviour
{
    public EnemyChase enemyChaseScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyChaseScript.StartChase();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyChaseScript.StopChase();
        }
    }
}
