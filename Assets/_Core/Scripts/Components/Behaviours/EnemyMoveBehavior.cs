using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class EnemyMoveBehavior : MonoBehaviour, IBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private CharacterController playerCharacterController;
    public float distanceToEvaluate = 1f;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerCharacterController = FindObjectOfType<CharacterController>();
    }
    public float Evaluate()
    {
        if (playerCharacterController == null) return 0;
        var magnitude = 1/(gameObject.transform.position - playerCharacterController.transform.position).magnitude;
        // Debug.Log("EnemyMoveBehavior::Evaluate(); -- magnitude: " + magnitude);
        if (magnitude < distanceToEvaluate) return 1f;
        else return 0f;
        // return magnitude;
    }
    public void Behave()
    {
        if (navMeshAgent != null && navMeshAgent.gameObject.activeInHierarchy)
        {
            animator.SetTrigger("WalkFWD");
            navMeshAgent?.SetDestination(playerCharacterController.transform.position);
        }
        // Debug.Log("EnemyMoveBehavior::Behave(); -- Move");
    }
}