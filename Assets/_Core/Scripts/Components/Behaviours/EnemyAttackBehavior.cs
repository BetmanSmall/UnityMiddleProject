using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAttackBehavior : MonoBehaviour, IBehaviour
{
    private Animator animator;
    private CharacterController playerCharacterController;
    public float distanceToEvaluate = 0.9f;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerCharacterController = FindObjectOfType<CharacterController>();
    }
    public float Evaluate()
    {
        if (playerCharacterController == null) return 0;
        var magnitude = 1/(gameObject.transform.position - playerCharacterController.transform.position).magnitude;
        // Debug.Log("EnemyAttackBehavior::Evaluate(); -- magnitude: " + magnitude);
        if (magnitude >= distanceToEvaluate) return 1f;
        else return 0f;
    }
    public void Behave()
    {
        if (Random.value < 0.5f) animator.SetTrigger("Attack1");
        else animator.SetTrigger("Attack2");
        // Debug.Log("EnemyAttackBehavior::Behave(); -- Attack");
    }
}