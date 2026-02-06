using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BehaviourManager : MonoBehaviour, IConvertGameObjectToEntity
{
    public List<IBehaviour> behaviours;
    public IBehaviour activeBehaviour;

    void Start()
    {
        if (behaviours == null) behaviours = new List<IBehaviour>();
        if (behaviours.Count == 0)
        {
            foreach (var behaviour in GetComponents<IBehaviour>())
            {
                behaviours.Add(behaviour);
            }
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<AIAgent>(entity);
    }
}

public struct AIAgent : IComponentData
{
    
}
