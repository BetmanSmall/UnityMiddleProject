using System.Collections.Generic;
using UnityEngine;

public interface IAbilityTarget : IAbility
{
    public List<GameObject> Targets { get; set; }
}