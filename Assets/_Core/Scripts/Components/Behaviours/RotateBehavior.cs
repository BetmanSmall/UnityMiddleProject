using UnityEngine;

public class RotateBehavior : MonoBehaviour, IBehaviour
{
    public CharacterController characterController;
    void Start()
    {
        characterController = FindObjectOfType<CharacterController>();
    }
    public float Evaluate()
    {
        if (characterController == null) return 0;
        var magnitude = 1/(this.gameObject.transform.position - characterController.transform.position).magnitude;
        Debug.Log("RotateBehavior::Evaluate(); -- magnitude: " + magnitude);
        return magnitude;
    }
    public void Behave()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 10);
        Debug.Log("RotateBehavior::Behave(); -- Rotate");
    }
}