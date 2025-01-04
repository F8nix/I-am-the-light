using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ItemCrafter : MonoBehaviour
{
    private int normalChance;
    private int magicChance;
    private int rareChance;

    private RarityEnum craftedRarity;

    private int prefixNumb;
    private int suffixNumb;

    private int magicPrefixMin = 1;
    private int magicPrefixMax = 2;
    private int magicSuffixMin = 1;
    private int magicSuffixMax = 2;

    private int rarePrefixMin = 2;
    private int rarePrefixMax = 3;
    private int rareSuffixMin = 2;
    private int rareSuffixMax = 3;

    private (string, float) _implicit;
    private List<(string, float)> prefixesList = new List<(string, float)>();
    private List<(string, float)> suffixesList = new List<(string, float)>();

    [SerializeField] public List<ModifierData> modifiers = new List<ModifierData>();
    // Start is called before the first frame update
    void Start()
    {
        normalChance = 79;
        magicChance = 18;
        rareChance = 3;
        CraftItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private RarityEnum GetRandomRarity() {
        int chanceSum = normalChance + magicChance + rareChance;
        int rarityHit = UnityEngine.Random.Range(0, chanceSum + 1);

        if(rarityHit <= normalChance){
            return RarityEnum.Normal;
        } else if (normalChance < rarityHit && rarityHit <= (normalChance + magicChance)){
            return RarityEnum.Magic;
        } else {
            return RarityEnum.Rare;
        }
    }

    private (string, float) GetRandomModifier(ModifierTypeEnum _modifierType) {
        ModifierData randomModifier;
        randomModifier = modifiers.Where((modifier)=>modifier.modifierType == _modifierType).RandomElement();
        if (randomModifier == null){
            Debug.Log("GetRandomModifier empty randomModifier");
        }
        randomModifier.SetModifierStrength();

        return (randomModifier.modifierName, randomModifier.modifierStrength);
    }

    private List<(string, float)> GetRandomModifier(ModifierTypeEnum _modifierType, int modifiersAmount) {
        List<ModifierData> modifiersList = new List<ModifierData>();
        ModifierData randomModifier;
            for (int i = 1; i < modifiersAmount + 1; i++){
                randomModifier = modifiers.
                    Where(modifier => modifier.modifierType == _modifierType).
                        Except(modifiersList).
                            RandomElement();
                    if (randomModifier == null){
                        Debug.Log("GetRandomModifier empty randomModifier");
                    }
                randomModifier.SetModifierStrength();
                modifiersList.Add(randomModifier);
            }
        return modifiersList.Select(modifier => (modifier.modifierName, modifier.modifierStrength)).ToList();
    }

    private void SetAffixesRange(RarityEnum rarity){
        prefixNumb = 0;
        suffixNumb = 0;
        
        if (rarity == RarityEnum.Normal){
            prefixNumb = 0;
            suffixNumb = 0;
        } else if(rarity == RarityEnum.Magic){
            prefixNumb = UnityEngine.Random.Range(magicPrefixMin, magicPrefixMax + 1);
            suffixNumb = UnityEngine.Random.Range(magicSuffixMin, magicSuffixMax + 1);
        } else if(rarity == RarityEnum.Rare){
            prefixNumb = UnityEngine.Random.Range(rarePrefixMin, rarePrefixMax + 1);
            suffixNumb = UnityEngine.Random.Range(rareSuffixMin, rareSuffixMax + 1);
        }
        Debug.Log(prefixNumb + (" :pref suff: ") + suffixNumb);
    }

    public Item CraftItem() {
        craftedRarity = RarityEnum.Rare;
        //test
        if(craftedRarity == RarityEnum.Normal){
            SetAffixesRange(craftedRarity);
            _implicit = GetRandomModifier(ModifierTypeEnum.Implicit);
            Item i = new Item(craftedRarity, _implicit);
            return i;
        }
        if(craftedRarity == RarityEnum.Magic){
            SetAffixesRange(craftedRarity);
            _implicit = GetRandomModifier(ModifierTypeEnum.Implicit);
            prefixesList = GetRandomModifier(ModifierTypeEnum.Prefix, prefixNumb);
            suffixesList = GetRandomModifier(ModifierTypeEnum.Suffix, suffixNumb);
            Item i = new Item(craftedRarity, _implicit, prefixesList, suffixesList);
            return i;
        }
        if(craftedRarity == RarityEnum.Rare){
            SetAffixesRange(craftedRarity);
            _implicit = GetRandomModifier(ModifierTypeEnum.Implicit);
            prefixesList = GetRandomModifier(ModifierTypeEnum.Prefix, prefixNumb);
            suffixesList = GetRandomModifier(ModifierTypeEnum.Suffix, suffixNumb);
            Item i = new Item(craftedRarity, _implicit, prefixesList, suffixesList);
            return i;
        }

        return null;
        //some fancy exception error

        /* item test
            Debug.Log(i.rarity + " " + i._implicit.Item1 + " " + i._implicit.Item2);
            for (int j = 0; j < i.prefixes.Count; j++){
                Debug.Log("Prefix " + i.prefixes[j].Item1 + " " + i.prefixes[j].Item2);
            }
            for (int k = 0; k < i.suffixes.Count; k++){
                Debug.Log("Suffix " + i.suffixes[k].Item1 + " " + i.suffixes[k].Item2);
            }
            */
    }
}
