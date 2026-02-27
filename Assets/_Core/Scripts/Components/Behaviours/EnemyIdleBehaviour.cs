using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class EnemyIdleBehaviour : MonoBehaviour, IBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float evaluate = 0.2f;
    private bool isIdle = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public float Evaluate()
    {
        if (navMeshAgent != null && navMeshAgent.velocity.magnitude > 0f)
        {
            isIdle = false;
        }
        return evaluate;
    }
    public void Behave()
    {
        if (isIdle) return;
        isIdle = true;
        // Debug.Log("EnemyIdleBehaviour::Behave(); -- Idle");
        animator.SetTrigger("Idle");
        navMeshAgent.ResetPath();
    }
}