using System;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsEvents : MonoBehaviour {
    [Serializable] public class CollisionEnter2DEvent : UnityEvent<Collision2D> { }
    [Serializable] public class CollisionStay2DEvent : UnityEvent<Collision2D> { }
    [Serializable] public class CollisionExit2DEvent : UnityEvent<Collision2D> { }
    [Serializable] public class TriggerEnter2DEvent : UnityEvent<Collider2D> { }
    [Serializable] public class TriggerStay2DEvent : UnityEvent<Collider2D> { }
    [Serializable] public class TriggerExit2DEvent : UnityEvent<Collider2D> { }
    [SerializeField] private CollisionEnter2DEvent m_OnCollisionEnter2D = new CollisionEnter2DEvent();
    [SerializeField] private CollisionStay2DEvent m_OnCollisionStay2D = new CollisionStay2DEvent();
    [SerializeField] private CollisionExit2DEvent m_OnCollisionExit2D = new CollisionExit2DEvent();
    [SerializeField] private TriggerEnter2DEvent m_OnTriggerEnter2D = new TriggerEnter2DEvent();
    [SerializeField] private TriggerStay2DEvent m_OnTriggerStay2D = new TriggerStay2DEvent();
    [SerializeField] private TriggerExit2DEvent m_OnTriggerExit2D = new TriggerExit2DEvent();
    [Serializable] public class CollisionEnterEvent : UnityEvent<Collision> { }
    [Serializable] public class CollisionStayEvent : UnityEvent<Collision> { }
    [Serializable] public class CollisionExitEvent : UnityEvent<Collision> { }
    [Serializable] public class TriggerEnterEvent : UnityEvent<Collider> { }
    [Serializable] public class TriggerStayEvent : UnityEvent<Collider> { }
    [Serializable] public class TriggerExitEvent : UnityEvent<Collider> { }
    [SerializeField] private CollisionEnterEvent m_OnCollisionEnter = new CollisionEnterEvent();
    [SerializeField] private CollisionStayEvent m_OnCollisionStay = new CollisionStayEvent();
    [SerializeField] private CollisionExitEvent m_OnCollisionExit = new CollisionExitEvent();
    [SerializeField] private TriggerEnterEvent m_OnTriggerEnter = new TriggerEnterEvent();
    [SerializeField] private TriggerStayEvent m_OnTriggerStay = new TriggerStayEvent();
    [SerializeField] private TriggerExitEvent m_OnTriggerExit = new TriggerExitEvent();

    public CollisionEnter2DEvent OnCollisionEnter2DEvent {
        get { return m_OnCollisionEnter2D; }
        set { m_OnCollisionEnter2D = value; }
    }
    
    public CollisionStay2DEvent OnCollisionStay2DEvent {
        get { return m_OnCollisionStay2D; }
        set { m_OnCollisionStay2D = value; }
    }
    
    public CollisionExit2DEvent OnCollisionExit2DEvent {
        get { return m_OnCollisionExit2D; }
        set { m_OnCollisionExit2D = value; }
    }
    
    public TriggerEnter2DEvent OnTriggerEnterEvent2D {
        get { return m_OnTriggerEnter2D; }
        set { m_OnTriggerEnter2D = value; }
    }
    
    public TriggerStay2DEvent OnTriggerStayEvent2D {
        get { return m_OnTriggerStay2D; }
        set { m_OnTriggerStay2D = value; }
    }
    
    public TriggerExit2DEvent OnTriggerExitEvent2D {
        get { return m_OnTriggerExit2D; }
        set { m_OnTriggerExit2D = value; }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        m_OnCollisionEnter2D.Invoke(col);
    }
    
    private void OnCollisionStay2D(Collision2D col) {
        m_OnCollisionStay2D.Invoke(col);
    }
    
    private void OnCollisionExit2D(Collision2D col) {
        m_OnCollisionExit2D.Invoke(col);
    }
    
    private void OnTriggerEnter2D(Collider2D col) {
        m_OnTriggerEnter2D.Invoke(col);
    }
    
    private void OnTriggerStay2D(Collider2D col) {
        m_OnTriggerStay2D.Invoke(col);
    }
    
    private void OnTriggerExit2D(Collider2D col) {
        m_OnTriggerExit2D.Invoke(col);
    }

    public CollisionEnterEvent OnCollisionEnterEvent {
        get { return m_OnCollisionEnter; }
        set { m_OnCollisionEnter = value; }
    }
    
    public CollisionStayEvent OnCollisionStayEvent {
        get { return m_OnCollisionStay; }
        set { m_OnCollisionStay = value; }
    }
    
    public CollisionExitEvent OnCollisionExitEvent {
        get { return m_OnCollisionExit; }
        set { m_OnCollisionExit = value; }
    }
    
    public TriggerEnterEvent OnTriggerEnterEvent {
        get { return m_OnTriggerEnter; }
        set { m_OnTriggerEnter = value; }
    }
    
    public TriggerStayEvent OnTriggerStayEvent {
        get { return m_OnTriggerStay; }
        set { m_OnTriggerStay = value; }
    }
    
    public TriggerExitEvent OnTriggerExitEvent {
        get { return m_OnTriggerExit; }
        set { m_OnTriggerExit = value; }
    }

    private void OnCollisionEnter(Collision col) {
        m_OnCollisionEnter.Invoke(col);
    }
    
    private void OnCollisionStay(Collision col) {
        m_OnCollisionStay.Invoke(col);
    }
    
    private void OnCollisionExit(Collision col) {
        m_OnCollisionExit.Invoke(col);
    }
    
    private void OnTriggerEnter(Collider col) {
        m_OnTriggerEnter.Invoke(col);
    }
    
    private void OnTriggerStay(Collider col) {
        m_OnTriggerStay.Invoke(col);
    }
    
    private void OnTriggerExit(Collider col) {
        m_OnTriggerExit.Invoke(col);
    }
}
