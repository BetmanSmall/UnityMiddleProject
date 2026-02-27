
using DG.Tweening;
using UnityEngine;

public class PressingAbillty : MonoBehaviour, IAbility
{
    [SerializeField] private float pressingDuration = 0.5f;
    [SerializeField] private bool onStart;
    [SerializeField] private bool loop;
    [SerializeField] private GameObject trapObject;
    
    private Vector3 startPosition;
    private bool isPressinging = false;

    public void Start()
    {
        if (trapObject == null) trapObject = transform.GetChild(0).gameObject;
        startPosition = trapObject.transform.localPosition;
        if (onStart)
        {
            Execute();
        }
    }

    public void Execute()
    {
        // Debug.Log("PressingAbillty::Execute(); -- trapObject.transform.localPosition: " + trapObject.transform.localPosition);
        if (trapObject == null) return;
        if (isPressinging) return;
        isPressinging = true;
        trapObject.transform.DOLocalMove(Vector3.zero, pressingDuration).OnComplete(() =>
        {
            trapObject.transform.DOLocalMove(startPosition, pressingDuration).OnComplete(() =>
            {
                isPressinging = false;
                if (loop) Execute();
            });
        });
    }
}