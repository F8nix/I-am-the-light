using UnityEngine;

[System.Serializable]
public class ModifierData
{
    public ModifierTypeEnum modifierType;

    public string modifierName;

    public float modifierStrength;
    public float modifierMinStr;
    public float modifierMaxStr;

    private void Start() {
        SetModifierStrength();
    }

    public void SetModifierStrength() {
        modifierStrength = Random.Range(modifierMinStr, modifierMaxStr);
    }
}