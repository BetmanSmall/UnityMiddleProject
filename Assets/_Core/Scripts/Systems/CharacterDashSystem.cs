using Unity.Entities;
using UnityEngine;

public class CharacterDashSystem : ComponentSystem
{
    private EntityQuery _dashQuery;

    protected override void OnCreate()
    {
        _dashQuery = GetEntityQuery(
            ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<DashData>(),
            ComponentType.ReadOnly<UserInputData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_dashQuery).ForEach(
            (Entity entity, UserInputData userInputData, ref InputData inputData) =>
            {
                if (inputData.Dash > 0f) {
                    if (userInputData.DashAction != null && userInputData.DashAction is IAbility ability)
                    {
                        ability.Execute();
                    }
                }
            }
        );
    }
}
