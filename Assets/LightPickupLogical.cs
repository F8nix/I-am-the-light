using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Events;

public class LightPickupLogical : MonoBehaviour
{
    public EnergyManager energyManagerRef;

    [SerializeField] public List<MultiplierData> multipliersList = new List<MultiplierData>();
    
    public LightPickupGraphical lightPickupGraphical;
    public PlayerLightCurrency playerLightCurrency;

    public float radius;
    public Collider2D[] lightsToPickUp;

    public LayerMask currencyLayer;


    public int cumulatedCurrency;
    public float cumulatedEnergy;
    //public float firstMultiplier;
    //public int firstMultiplierReq;

    public float thresholdLightMultiplier;


    void Start()
    {
        radius = gameObject.GetComponent<CircleCollider2D>().radius;
        //firstMultiplier = 1.2f;
        //firstMultiplierReq = 5;
        thresholdLightMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        lightPickupGraphical.onDissappearence += PickupLight;
        energyManagerRef.onThreshold += SetThresholdMultiplier;
    }
    private void OnDisable() {
        lightPickupGraphical.onDissappearence -= PickupLight;
        energyManagerRef.onThreshold -= SetThresholdMultiplier;
    }


    public void PickupLight() {
        lightsToPickUp = Physics2D.OverlapCircleAll(transform.position, radius, currencyLayer);
        
        float multiplier = 0;
        cumulatedCurrency = 0;
        cumulatedEnergy = 0;
        
        if(lightsToPickUp.Length < 1){
            Debug.Log("Nothing to pick up");
            return;
        }
        foreach (Collider2D light in lightsToPickUp)
        {
            LightSpawnerManager.Instance.currentLight--;
            LightCurrencyOne currency = light.gameObject.GetComponent<LightCurrencyOne>();
            cumulatedCurrency += currency.lightAmount;
            cumulatedEnergy += currency.energyAmount;
            Destroy(light.gameObject);
        }
        multiplier = CalculateMultiplier(lightsToPickUp.Length);
        if(multiplier > 0){
            playerLightCurrency.CurrentLight += multiplier * cumulatedCurrency * thresholdLightMultiplier;
            energyManagerRef.remainingEnergy += multiplier * cumulatedEnergy;
        } else {
            Debug.Log("CalcMulti func didn't work? Multiplier is: " + multiplier + " zero right?");
        }
        Debug.Log("Current light: " + playerLightCurrency.CurrentLight + " Multiplier: " +multiplier + " Threshold multi: " + thresholdLightMultiplier);
        //DYnamic object pooling
    }

    private float CalculateMultiplier(int lightsGathered) {
        foreach (MultiplierData multiplier in multipliersList)
        {
            if(lightsGathered >= multiplier.multiplierProc){
                return multiplier.multiplierAmount;
            }
        }
        return 1;

        //more multipliers = better handling, like with foreach and continue
    }

    private void SetThresholdMultiplier(float _thresholdLightMultiplier) {
        thresholdLightMultiplier = _thresholdLightMultiplier;
    }
}
