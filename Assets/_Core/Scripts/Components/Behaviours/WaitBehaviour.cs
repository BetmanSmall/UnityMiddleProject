using UnityEngine;

public class WaitBehaviour : MonoBehaviour, IBehaviour
{
    public float evaluate = 0.5f;
    public float Evaluate()
    {
        return evaluate;
    }
    public void Behave()
    {
        // Debug.Log("WaitBehaviour::Behave(); -- Wait");
    }
}