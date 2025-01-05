using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChanger : MonoBehaviour
{
    public float circleChange;

    public float lightMultiplier;
    public float lightMultiplierProc;

    public float lightMultiplierProcDecrease;


    public float initialEnergy;
    public float maxEnergy;
    public float energyThresholdProcDecrease;
    int currentThresholdIndex = 0;
    
    public float energyDrainMultiplier;
    public float energyDrainMultiplierUpgrade;
    public float energyDrainUpgradeTime;

    //public int cumulatedCurrency; -> this one stays prob
    //public int cumulatedEnergy; -> this one stays prob
    public LightPickupLogical lightPickupLogical;

    public int cumulatedLight;
    public float cumulatedEnergy;


    public List<Item> socketedItems = new List<Item>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        lightPickupLogical.onLightPickup += SetCumulatedCurrency;
    }

    private void OnDisable() {
        lightPickupLogical.onLightPickup -= SetCumulatedCurrency;
    }

    private void SetCumulatedCurrency((int, float) cumulatedCurrencyTuple) {
        cumulatedLight = cumulatedCurrencyTuple.Item1;
        cumulatedEnergy = cumulatedCurrencyTuple.Item1;
    }

    /*
    private float CalculateCircleStatChange(){}
    */

    public float GetCircleStatChange(PickupCircleEnum circleType) { // d = 2r    d -> scale  r -> radius
        if(circleType == PickupCircleEnum.Graphical){
            return circleChange * 2;
        }
        if(circleType == PickupCircleEnum.Logical){
            return circleChange;
        }
        return 0;
    }


    public void SetStats() {}

    public float GetAdditionalLightAmount(int additionalLightAmount, float additionalLightAmountPercent) {
        
        while(additionalLightAmountPercent > 1.0f){ //for every 100% you get one more
            additionalLightAmountPercent -= 1.0f;
            additionalLightAmount += 1;
        }
        return additionalLightAmount;
    }
}
