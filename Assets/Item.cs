using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public RarityEnum rarity;

    public (string, float) _implicit;

    private Dictionary<int, (string, float)> prefixes;
    private Dictionary<int, (string, float)> suffixes;

    //Normal Rarity
    public Item(RarityEnum rarity, (string, float) _implicit){
        this.rarity = rarity;
        this._implicit = _implicit;
    }

    //Magic and Rare
    public Item(RarityEnum rarity, (string, float) _implicit, Dictionary<int, (string, float)> prefixes, Dictionary<int, (string, float)> suffixes){
        this.rarity = rarity;
        this._implicit = _implicit;
        this.prefixes = prefixes;
        this.suffixes = suffixes;
    }
}
