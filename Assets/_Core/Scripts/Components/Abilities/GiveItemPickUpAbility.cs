using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class GiveItemPickUpAbility : MonoBehaviour, IAbilityTarget, IConvertGameObjectToEntity, IItem
{
    public GameObject _uiItemPrefab;
    public List<GameObject> Targets { get; set; }
    public GameObject uiItemPrefab => _uiItemPrefab;

    private Entity _entity;
    private EntityManager _entityManager;

    public void Execute()
    {
        foreach (var target in Targets)
        {
            var character = target.GetComponent<CharacterLevel>();
            if (character == null) return;
            var item = Instantiate(uiItemPrefab, character.InventoryUIRoot.transform, false);
            var ability = item.GetComponent<IAbilityTarget>();
            if (ability != null) ability.Targets = new List<GameObject> { target };
            Destroy(this.gameObject);
            _entityManager.DestroyEntity(_entity);
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        this._entity = entity;
        this._entityManager = dstManager;
    }

    public void UseItem(CharacterLevel characterLevel)
    {
        throw new System.NotImplementedException();
    }
}
