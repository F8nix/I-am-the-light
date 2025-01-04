using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        int rarityHit = Random.Range(0, chanceSum + 1);

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
        //Debug.Log(randomModifier.modifierName + " " + randomModifier.modifierStrength);
        return (randomModifier.modifierName, randomModifier.modifierStrength);
    }

    private int SetAffixesRange(RarityEnum rarity){
        prefixNumb = 0;
        suffixNumb = 0;
        
        if (rarity == RarityEnum.Normal){
            prefixNumb = 0;
            suffixNumb = 0;
        } else if(rarity == RarityEnum.Magic){
            prefixNumb = Random.Range(magicPrefixMin, magicPrefixMax + 1);
            suffixNumb = Random.Range(magicSuffixMin, magicSuffixMax + 1);
        } else if(rarity == RarityEnum.Rare){
            prefixNumb = Random.Range(rarePrefixMin, rarePrefixMax + 1);
            suffixNumb = Random.Range(rareSuffixMin, rareSuffixMax + 1);
        }
        Debug.Log("AffixRange didn't work");
        return -1;
    }

    public Item CraftItem() {
        craftedRarity = RarityEnum.Normal;
        //test
        if(craftedRarity == RarityEnum.Normal){
            SetAffixesRange(craftedRarity);
            _implicit = GetRandomModifier(ModifierTypeEnum.Implicit);
        }
        Item i = new Item(craftedRarity, _implicit);
        Debug.Log(i.rarity + " " + i._implicit.Item1 + " " + i._implicit.Item2);
        return i;
    }
}
