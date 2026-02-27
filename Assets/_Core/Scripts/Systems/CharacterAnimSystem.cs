using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CharacterAnimSystem : ComponentSystem
{
    private EntityQuery _query;
    
    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<AnimData>(), ComponentType.ReadOnly<Animator>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach(
            (Entity entity, ref InputData inputData, Animator animator, UserInputData userInputData) =>
            {
                animator.SetBool(userInputData.moveAnimHash, Mathf.Abs(inputData.Move.x) > 0.01f || Mathf.Abs(inputData.Move.y) > 0.01f);

                if (userInputData.moveAnimSpeedHash != string.Empty)
                {
                    float currentInputStrength = math.length(inputData.Move);
                    float normalizedInput = math.clamp(currentInputStrength * userInputData.speed, 0f, 1f);
                    animator.SetFloat(userInputData.moveAnimSpeedHash, normalizedInput, 0.1f, Time.DeltaTime);
                    // animator.SetFloat(userInputData.moveAnimSpeedHash, userInputData.speed*math.distancesq(inputData.Move.x, inputData.Move.y));
                }
            }
        );
    }
}
