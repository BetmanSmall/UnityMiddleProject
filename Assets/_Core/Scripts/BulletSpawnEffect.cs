using UnityEngine;
using Zenject;

public class BulletSpawnEffect : MonoBehaviour
{
    [SerializeField] private GameObject[] trailEffectPrefabs;
    [Inject] private DiContainer _container;

    private void Start()
    {
        var effectPrefab = trailEffectPrefabs[Random.Range(0, trailEffectPrefabs.Length)];
        if (effectPrefab != null)
        {
            _container.InstantiatePrefab(effectPrefab, transform.position, transform.rotation, transform);
        }
    }
}
