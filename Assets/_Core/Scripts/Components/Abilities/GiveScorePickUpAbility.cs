using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class GiveScorePickUpAbility : MonoBehaviour, IAbilityTarget, IConvertGameObjectToEntity
{
    public List<GameObject> Targets { get; set; }

    private Entity _entity;
    private EntityManager _entityManager;

    public void Execute()
    {
        foreach (var target in Targets)
        {
            var character = target.GetComponent<CharacterLevel>();
            if (character != null) character.AddScore(3);
            Destroy(this.gameObject);
            _entityManager.DestroyEntity(_entity);
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        this._entity = entity;
        this._entityManager = dstManager;
    }
}
