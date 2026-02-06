using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class EnemyIdleBehaviour : MonoBehaviour, IBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float evaluate = 0.2f;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public float Evaluate()
    {
        return evaluate;
    }
    public void Behave()
    {
        // Debug.Log("EnemyIdleBehaviour::Behave(); -- Idle");
        animator.SetTrigger("Idle");
        navMeshAgent.ResetPath();
    }
}