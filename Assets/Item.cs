using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public RarityEnum rarity;

    public (string, float) _implicit;

    public List<(string, float)> prefixes;
    public List<(string, float)> suffixes;

    //Normal Rarity
    public Item(RarityEnum rarity, (string, float) _implicit){
        this.rarity = rarity;
        this._implicit = _implicit;
    }

    //Magic and Rare
    public Item(RarityEnum rarity, (string, float) _implicit, List<(string, float)> prefixes, List<(string, float)> suffixes){
        this.rarity = rarity;
        this._implicit = _implicit;
        this.prefixes = prefixes;
        this.suffixes = suffixes;
    }
}
