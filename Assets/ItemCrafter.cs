using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrafter : MonoBehaviour
{
    private int normalChance;
    private int magicChance;
    private int rareChance;


    [SerializeField] public List<ModifierData> modifiers = new List<ModifierData>();
    // Start is called before the first frame update
    void Start()
    {
        normalChance = 79;
        magicChance = 18;
        rareChance = 3;
        for (int i =0; i < 100; i++){
            Debug.Log(GetRandomRarity());
        }
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
}
