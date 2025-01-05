using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaThresholdManager : MonoBehaviour
{
    public static ArenaThresholdManager Instance { get; private set; }

    public EnergyManager energyManagerRef;

    [SerializeField] public ThresholdData[] arenaThresholds;

    public int currentThresholdIndex = 0;
    public float thresholdLightMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() 
    {    
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void OnEnable() {
        energyManagerRef.onThreshold += SetLightThresholdMultiplier;
    }
    private void OnDisable() {
        energyManagerRef.onThreshold -= SetLightThresholdMultiplier;
    }

    private void SetLightThresholdMultiplier(float _thresholdLightMultiplier) {
        thresholdLightMultiplier = _thresholdLightMultiplier;
    }
}
