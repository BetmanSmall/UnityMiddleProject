using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed = 1f;
    public string moveAnimHash = "Moving";
    public string moveAnimSpeedHash = "MovingAnimSpeed";

    public MonoBehaviour ShootAction;
    public MonoBehaviour DashAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());
        dstManager.AddComponentData(entity, new MoveData
        {
            Speed = speed / 100f
        });
        if (ShootAction != null && ShootAction is IAbility)
        {
            dstManager.AddComponentData(entity, new ShootData());
        }
        if (DashAction != null && DashAction is IAbility)
        {
            dstManager.AddComponentData(entity, new DashData());
        }
        if (moveAnimHash != string.Empty)
        {
            dstManager.AddComponentData(entity, new AnimData());
        }
    }
}

public struct InputData : IComponentData
{
    public float2 Move;
    public float Shoot;
    public float Dash;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct ShootData : IComponentData
{

}

public struct DashData : IComponentData
{

}

public struct AnimData : IComponentData
{

}
