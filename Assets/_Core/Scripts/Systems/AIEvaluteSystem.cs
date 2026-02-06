using Unity.Entities;
using UnityEngine;

public class AIEvaluteSystem : ComponentSystem
{
    private EntityQuery _evaluteQuery;
    
    protected override void OnCreate()
    {
        _evaluteQuery = GetEntityQuery(ComponentType.ReadOnly<AIAgent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_evaluteQuery).ForEach(
            (Entity entity, BehaviourManager manager) =>
            {
                float higtScore = float.MinValue;
                manager.activeBehaviour = null;
                foreach (var behaviour in manager.behaviours)
                {
                    if (behaviour is IBehaviour ai)
                    {
                        var currentScore = ai.Evaluate();
                        if (currentScore > higtScore)
                        {
                            higtScore = currentScore;
                            manager.activeBehaviour = ai;
                        }
                    }
                }
                Debug.Log("AIEvaluteSystem::OnUpdate(); -- activeBehaviour: " + manager.activeBehaviour);
            }
        );
    }
}
