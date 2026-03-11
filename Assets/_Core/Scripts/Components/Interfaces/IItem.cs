using System;
using UnityEngine;

public interface IItem
{
    GameObject uiItemPrefab { get; }
    void UseItem(CharacterLevel characterLevel);
}