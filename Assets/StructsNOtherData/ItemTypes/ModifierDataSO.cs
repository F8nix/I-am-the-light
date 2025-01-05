using UnityEngine;

[CreateAssetMenu(fileName = "ItemModifierData", menuName = "ScriptableObjects/ItemModifierSO", order = 2)]
public class ModifierDataSO : ScriptableObject
{
    public ModifierTypeEnum modifierType;

    public string modifierName;

    public float modifierMinStr;
    public float modifierMaxStr;
}