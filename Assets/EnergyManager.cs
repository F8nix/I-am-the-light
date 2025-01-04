using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

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

    public event Action<float> onThreshold;

    public bool running = true;

    public TextMeshProUGUI energyDisplay;


    [SerializeField] public ThresholdData[] energyThresholds;
    int currentThresholdIndex = 0;

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
        energyDrainMultiplierUpgrade = 0.1f;
        StartCoroutine(UpgradeDrainMultiplier(energyDrainUpgradeTime));
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnergy -= Time.deltaTime * energyDrainMultiplier;
        formattedEnergy = Mathf.FloorToInt(remainingEnergy);

        energyDrained += Time.deltaTime;
        formattedEnergyDrained = Mathf.FloorToInt(energyDrained);
        energyDisplay.text = string.Format("Energy: {0}", formattedEnergy);
        if(formattedEnergyDrained > energyThresholds[currentThresholdIndex].thresholdProc) {
            onThreshold?.Invoke(energyThresholds[currentThresholdIndex].lightMultiplier);
            currentThresholdIndex++;
        }
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
