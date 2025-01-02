using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public float initialEnergy;
    public float maxEnergy;
    public float remainingEnergy;
    public int formattedEnergy;
    

    public float energyDrained;
    public int formattedEnergyDrained;
    public float energyDrainMultiplier;
    public float energyDrainMultiplierUpgrade;
    public float energyDrainUpgradeTime;

    public bool running = true;

    public TextMeshProUGUI energyDisplay;

    private void Awake() {
        remainingEnergy = initialEnergy;
        if(initialEnergy > maxEnergy){
            initialEnergy = maxEnergy;
        }
    }
    void Start()
    {
        energyDrained = 0;
        energyDrainMultiplier = 1;
        StartCoroutine(UpgradeDrainMultiplier(energyDrainUpgradeTime));
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnergy -= Time.deltaTime;
        energyDrained += Time.deltaTime;
        formattedEnergy = Mathf.FloorToInt(remainingEnergy);
        formattedEnergyDrained = Mathf.FloorToInt(energyDrained);
        energyDisplay.text = string.Format("Energy: {0}", formattedEnergy);
    }

    private IEnumerator UpgradeDrainMultiplier(float eDrainUpgTime){
        while(running){
            yield return new WaitForSeconds(eDrainUpgTime);
            energyDrainMultiplier += energyDrainMultiplierUpgrade;
            //Debug.Log("EnergyMulti: " + energyDrainMultiplier);
        }
    }

    private void ChangeDrainUpgradeState(bool runningg){
        running = runningg;
        if (running){
            StartCoroutine(UpgradeDrainMultiplier(energyDrainUpgradeTime));
        }
    }
}
