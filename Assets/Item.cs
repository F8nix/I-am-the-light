using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public RarityEnum rarity;

    public ModifierData _implicit;

    public List<ModifierData> prefixes;
    public List<ModifierData> suffixes;

    //Normal Rarity
    public Item(RarityEnum rarity, ModifierData _implicit)
    {
        this.rarity = rarity;
        this._implicit = _implicit;
    }

    //Magic and Rare
    public Item(RarityEnum rarity, ModifierData _implicit, List<ModifierData> prefixes, List<ModifierData> suffixes)
    {
        this.rarity = rarity;
        this._implicit = _implicit;
        this.prefixes = prefixes;
        this.suffixes = suffixes;
    }
}
