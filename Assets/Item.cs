using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private (string, float) _implicit;

    private Dictionary<int, (string, float)> prefixes;
    private Dictionary<int, (string, float)> suffixes;

    private int prefixNumb;
    //private int prefixNumbMin;
    //private int prefixNumbMax;

    private int suffixNumb;
    //private int suffixNumbMin;
    //private int suffixNumbMax;

    private int magicPrefixMin;
    private int magicPrefixMax;
    private int magicSuffixMin;
    private int magicSuffixMax;

    private int rarePrefixMin;
    private int rarePrefixMax;
    private int rareSuffixMin;
    private int rareSuffixMax;
    // Start is called before the first frame update
    void Start()
    {
        magicPrefixMin = 1;
        magicPrefixMax = 2;
        magicSuffixMin = 1;
        magicSuffixMax = 2;

        rarePrefixMin = 2;
        rarePrefixMax = 3;
        rareSuffixMin = 2;
        rareSuffixMax = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetAffixesRange(RarityEnum rarity){
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
    }

    //Normal Rarity
    public Item(RarityEnum rarity, (string, float) _implicit){
        SetAffixesRange(rarity);
        this._implicit = _implicit;
    }

    //Magic and Rare
    public Item(RarityEnum rarity, (string, float) _implicit, Dictionary<int, (string, float)> prefixes, Dictionary<int, (string, float)> suffixes){
        SetAffixesRange(rarity);
        this._implicit = _implicit;
        this.prefixes = prefixes;
        this.suffixes = suffixes;
    }
}
