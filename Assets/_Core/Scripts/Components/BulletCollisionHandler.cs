using System;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public GameObject[] explosionEffectPrefabs;
    public LayerMask collisionLayer = ~0;
    public bool destroyOnCollision = true;
    void Start()
    {
        Collider collider = GetComponentInChildren<Collider>();
        PhysicsEvents physicsEvents = collider.gameObject.GetComponent<PhysicsEvents>();
        if (physicsEvents == null)
            physicsEvents = collider.gameObject.AddComponent<PhysicsEvents>();
        physicsEvents.OnCollisionEnterEvent.AddListener(OnCollisionEnterEvent);
        physicsEvents.OnTriggerEnterEvent.AddListener(OnTriggerEnterEvent);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BulletCollisionHandler::OnCollisionEnter(); -- collision.gameObject: " + collision.gameObject);
        OnCollisionEnterEvent(collision);
    }
    private void OnCollisionEnterEvent(Collision collision)
    {
        Debug.Log("BulletCollisionHandler::OnCollisionEnterEvent(); -- collision.gameObject: " + collision.gameObject);
        CheckAndPlayExplosion(collision.gameObject, () =>
        {
            PlayExplosion(collision.contacts[0].point, collision.contacts[0].normal);
        });
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BulletCollisionHandler::OnTriggerEnter(); -- other.gameObject: " + other.gameObject);
        OnTriggerEnterEvent(other);
    }
    private void OnTriggerEnterEvent(Collider other)
    {
        Debug.Log("BulletCollisionHandler::OnTriggerEnterEvent(); -- other.gameObject: " + other.gameObject);
        CheckAndPlayExplosion(other.gameObject, () =>
        {
            PlayExplosion(transform.position, transform.forward);
        });
    }
    private void CheckAndPlayExplosion(GameObject other, Action action)
    {
        if (this == null || gameObject == null)
        {
            return;
        }
        if (((1 << other.layer) & collisionLayer) == 0)
        {
            return;
        }
        action?.Invoke();
        if (destroyOnCollision)
        {
            DestroyObject();
        }
    }
    private void PlayExplosion(Vector3 position, Vector3 normal)
    {
        if (explosionEffectPrefabs == null || explosionEffectPrefabs.Length == 0)
        {
            return;
        }
        int randomIndex = UnityEngine.Random.Range(0, explosionEffectPrefabs.Length);
        GameObject effectPrefab = explosionEffectPrefabs[randomIndex];
        if (effectPrefab != null)
        {
            Quaternion rotation = Quaternion.LookRotation(normal);
            var explosion = Instantiate(effectPrefab, position, rotation);
            var particles = explosion.GetComponentInChildren<ParticleSystem>();
            if (particles != null)
            {
                float lifetime = particles.main.duration + particles.main.startLifetime.constant;
                Destroy(explosion, lifetime + 0.1f);
            }
            else
            {
                Destroy(explosion, 1f);
            }
        }
    }
    private void DestroyObject()
    {
        Collider collider = GetComponentInChildren<Collider>();
        PhysicsEvents physicsEvents = collider.gameObject.GetComponent<PhysicsEvents>();
        if (physicsEvents != null) {
            physicsEvents.OnCollisionEnterEvent.RemoveListener(OnCollisionEnterEvent);
            physicsEvents.OnTriggerEnterEvent.RemoveListener(OnTriggerEnterEvent);
        }
        Destroy(gameObject);
    }
}
