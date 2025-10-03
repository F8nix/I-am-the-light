using System;
using UnityEngine;

[Serializable]
public class ModifierData
{
    public ModifierDataSO modifierData;
    public float modifierStrength;
    public ModifierData(ModifierDataSO data)
    {
        modifierData = data;
        modifierStrength = Mathf.Round(UnityEngine.Random.Range(modifierData.modifierMinStr, modifierData.modifierMaxStr + 0.01f) * 100f) * 0.01f;
    }
}