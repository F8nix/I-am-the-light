using UnityEngine;
public class ModifierData
{
    public ModifierDataSO modifierData;
    public float modifierStrength;
    public ModifierData (ModifierDataSO data) {
        modifierData = data;
        modifierStrength = Random.Range(modifierData.modifierMinStr, modifierData.modifierMaxStr + 1);
    }
}