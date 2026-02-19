using UnityEngine;

public class BulletSpawnEffect : MonoBehaviour
{
    [SerializeField] private GameObject[] trailEffectPrefabs;
    private void Start()
    {
        Instantiate(trailEffectPrefabs[Random.Range(0, trailEffectPrefabs.Length)], transform.position, transform.rotation, transform);
    }
}
