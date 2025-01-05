using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class LightManager : MonoBehaviour
{
    public int lightAmountGained;
    [SerializeField] public List<MultiplierData> multipliersList = new List<MultiplierData>();
    private void Awake() {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float CalculateMultiplier(int lightsGathered) {
        foreach (MultiplierData multiplier in multipliersList)
        {
            if(lightsGathered >= multiplier.multiplierProc){
                return multiplier.multiplierAmount;
            }
        }
        return 1;
    }
    //playerLightCurrency.CurrentLight += multiplier * cumulatedCurrency * thresholdLightMultiplier;
}
