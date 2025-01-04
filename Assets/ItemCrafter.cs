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

    private int magicPrefixMin = 1;
    private int magicPrefixMax = 2;
    private int magicSuffixMin = 1;
    private int magicSuffixMax = 2;

    private int rarePrefixMin = 2;
    private int rarePrefixMax = 3;
    private int rareSuffixMin = 2;
    private int rareSuffixMax = 3;

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

    private (int, int) SetAffixesRange(RarityEnum rarity){
        int prefixNumb = 0;
        int suffixNumb = 0;
        
        if (rarity == RarityEnum.Normal){
            return (0, 0);
        } else if(rarity == RarityEnum.Magic){
            prefixNumb = UnityEngine.Random.Range(magicPrefixMin, magicPrefixMax + 1);
            suffixNumb = UnityEngine.Random.Range(magicSuffixMin, magicSuffixMax + 1);
            return (prefixNumb, suffixNumb);
        } else { //rare
            prefixNumb = UnityEngine.Random.Range(rarePrefixMin, rarePrefixMax + 1);
            suffixNumb = UnityEngine.Random.Range(rareSuffixMin, rareSuffixMax + 1);
            return (prefixNumb, suffixNumb);
        }
        //Debug.Log(prefixNumb + (" :pref suff: ") + suffixNumb);
    }

    public Item CraftItem() {
        craftedRarity = RarityEnum.Magic;
        //test
        (int prefixesAmount, int suffixesAmount) = SetAffixesRange(craftedRarity);
        List<(string, float)> prefixesList = GetRandomModifier(ModifierTypeEnum.Prefix, prefixesAmount);
        List<(string, float)> suffixesList = GetRandomModifier(ModifierTypeEnum.Suffix, suffixesAmount);
        Item i = new Item(craftedRarity, GetRandomModifier(ModifierTypeEnum.Implicit), prefixesList, suffixesList);
        Debug.Log(i.rarity + " " + i._implicit.Item1 + " " + i._implicit.Item2);
            for (int j = 0; j < i.prefixes.Count; j++){
                Debug.Log("Prefix " + i.prefixes[j].Item1 + " " + i.prefixes[j].Item2);
            }
            for (int k = 0; k < i.suffixes.Count; k++){
                Debug.Log("Suffix " + i.suffixes[k].Item1 + " " + i.suffixes[k].Item2);
            }
        return i;


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
