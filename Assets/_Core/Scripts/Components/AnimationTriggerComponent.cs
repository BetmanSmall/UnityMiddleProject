using UnityEngine;

public class AnimationTriggerComponent : MonoBehaviour
{
    [Header("Animation Triggers")]
    public string attacking1Trigger = "Attacking_1";
    public string attacking2Trigger = "Attacking_2";
    public string takeDamageTrigger = "TakeDamage";
    public string dieTrigger = "Die";
    
    [Header("Animator Reference")]
    public Animator animator;
    
    [Header("Animation Settings")]
    public bool canAnimate = true;
    public bool randomizeAttackAnimations = true;
    
    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        
        if (animator == null)
        {
            Debug.LogWarning($"No Animator found on {gameObject.name}, animations will not work");
        }
    }
    
    public void TriggerAttack()
    {
        if (!canAnimate || animator == null) return;
        
        if (randomizeAttackAnimations && Random.value > 0.5f)
        {
            animator.SetTrigger(attacking2Trigger);
        }
        else
        {
            animator.SetTrigger(attacking1Trigger);
        }
    }
    
    public void TriggerTakeDamage()
    {
        if (!canAnimate || animator == null) return;
        animator.SetTrigger(takeDamageTrigger);
    }
    
    public void TriggerDeath()
    {
        if (!canAnimate || animator == null) return;
        animator.SetTrigger(dieTrigger);
    }
    
    public void ResetTriggers()
    {
        if (animator == null) return;
        
        animator.ResetTrigger(attacking1Trigger);
        animator.ResetTrigger(attacking2Trigger);
        animator.ResetTrigger(takeDamageTrigger);
        animator.ResetTrigger(dieTrigger);
    }
}