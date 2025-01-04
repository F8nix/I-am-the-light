using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemTypeData", menuName = "ScriptableObjects/ItemTypeSO", order = 1)]
public class ItemTypeSO : ScriptableObject
{
    public List<ModifierData> modifiers = new List<ModifierData>();
    public ItemTypeEnum itemType;
    public ItemTierEnum itemTier;
    //public Sprite itemSprite;
}