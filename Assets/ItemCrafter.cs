using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ItemCrafter : MonoBehaviour
{
    public static ItemCrafter Instance { get; private set; }

    private int normalChance;
    private int magicChance;
    private int rareChance;

    private const int magicPrefixMin = 1;
    private const int magicPrefixMax = 2;
    private const int magicSuffixMin = 1;
    private const int magicSuffixMax = 2;

    private const int rarePrefixMin = 2;
    private const int rarePrefixMax = 3;
    private const int rareSuffixMin = 2;
    private const int rareSuffixMax = 3;

    [SerializeField] public List<ItemTypeSO> modifiersData = new List<ItemTypeSO>();
    public List<Item> testItems = new List<Item>();
    void Start()
    {
        normalChance = 79;
        magicChance = 18;
        rareChance = 3;

        testItems.Add(CraftItem(ItemTypeEnum.Energy));
        testItems.Add(CraftItem(ItemTypeEnum.Light));
    }

    private void Awake() 
    {    
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
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

    private ModifierData GetRandomModifier(ModifierTypeEnum _modifierType, List<ModifierDataSO> modifiers) {
        ModifierDataSO randomModifier;
        randomModifier = modifiers.Where((modifier)=>modifier.modifierType == _modifierType).RandomElement();
        if (randomModifier == null){
            Debug.Log("GetRandomModifier empty randomModifier");
        }
        ModifierData modifier = new ModifierData(randomModifier);
        return modifier;
    }

    private List<ModifierData> GetRandomModifier(ModifierTypeEnum _modifierType, List<ModifierDataSO> modifiers, int modifiersAmount) {
        List<ModifierDataSO> modifiersList = new List<ModifierDataSO>();
        ModifierDataSO randomModifier;
            for (int i = 1; i < modifiersAmount + 1; i++){
                randomModifier = modifiers.
                    Where(modifier => modifier.modifierType == _modifierType).
                        Except(modifiersList).
                            RandomElement();
                    if (randomModifier == null){
                        Debug.Log("GetRandomModifier empty randomModifier");
                    }
                modifiersList.Add(randomModifier);
            }
        return modifiersList.Select(modifier => new ModifierData(modifier)).ToList();
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

    public Item CraftItem(ItemTypeEnum itemType) {
        RarityEnum craftedRarity = RarityEnum.Magic;
        //test
        (int prefixesAmount, int suffixesAmount) = SetAffixesRange(craftedRarity);
        List<ModifierDataSO> modifiers = modifiersData.Find(item => item.itemType == itemType).modifiers;
        List<ModifierData> prefixesList = GetRandomModifier(ModifierTypeEnum.Prefix, modifiers, prefixesAmount);
        List<ModifierData> suffixesList = GetRandomModifier(ModifierTypeEnum.Suffix, modifiers, suffixesAmount);
        Item item = new Item(craftedRarity, GetRandomModifier(ModifierTypeEnum.Implicit, modifiers), prefixesList, suffixesList);
        
            Debug.Log(item.rarity + " " + item._implicit.modifierData.modifierName + " " + item._implicit.modifierStrength);
            for (int i = 0; i < item.prefixes.Count; i++){
                Debug.Log("Prefix " + item.prefixes[i].modifierData.modifierName + " " + item.prefixes[i].modifierStrength);
            }
            for (int i = 0; i < item.suffixes.Count; i++){
                Debug.Log("Suffix " + item.suffixes[i].modifierData.modifierName + " " + item.suffixes[i].modifierStrength);
            }

        return item;
            // item test
            
            
    }
}
