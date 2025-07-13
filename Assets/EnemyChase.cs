using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Animator animator;

    private bool shouldChase = false;

    void Update()
    {
        if (shouldChase && player != null)
        {
            agent.SetDestination(player.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    public void StartChase()
    {
        shouldChase = true;
    }

    public void StopChase()
    {
        shouldChase = false;
        agent.ResetPath();
    }
}
