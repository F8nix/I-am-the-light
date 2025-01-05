using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using System;

public class LightPickupLogical : MonoBehaviour
{   
    public EnergyManager energyManagerRef;
    public LightManager lightManagerRef;
    
    public LightPickupGraphical lightPickupGraphical;
    public PlayerLightCurrency playerLightCurrency;

    public float baseRadius;
    public Collider2D[] lightsToPickUp;

    public LayerMask currencyLayer;


    private int additionalLightAmount = 0; //we need to get it from StatChanger
    public int cumulatedLight;
    public float cumulatedEnergy;


    public event Action<(int, float)> onLightPickup;

    void Start()
    {
        baseRadius = gameObject.GetComponent<CircleCollider2D>().radius;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        lightPickupGraphical.onDissappearence += PickupLight;
    }
    private void OnDisable() {
        lightPickupGraphical.onDissappearence -= PickupLight;

    }


    public void PickupLight() {
        lightsToPickUp = Physics2D.OverlapCircleAll(transform.position, baseRadius, currencyLayer);
        
        cumulatedLight = 0;
        cumulatedEnergy = 0;
        
        if(lightsToPickUp.Length < 1){
            Debug.Log("Nothing to pick up");
            return;
        }
        foreach (Collider2D lightCollider in lightsToPickUp)
        {
            LightSpawnerManager.Instance.currentLight--;
            LightOne lightBasic = lightCollider.gameObject.GetComponent<LightOne>();
            cumulatedLight += lightBasic.baseLightAmount + additionalLightAmount;
            cumulatedEnergy += lightBasic.baseEnergyAmount;
            Destroy(lightCollider.gameObject);
            //DYnamic object pooling
        }
        (int, float) cumulatedCurrency = (cumulatedLight, cumulatedEnergy);
        onLightPickup?.Invoke(cumulatedCurrency);
        lightManagerRef.CalculateMultiplier(lightsToPickUp.Length);
        
    }

    

    
}
