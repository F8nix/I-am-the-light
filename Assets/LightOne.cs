using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOne : MonoBehaviour
{
    public int baseLightAmount;
    public float baseEnergyAmount;
    // Start is called before the first frame update
    void Start()
    {
        baseLightAmount = LightSpawnerManager.Instance.lightTypes[0].lightAmount;
        baseEnergyAmount = LightSpawnerManager.Instance.lightTypes[0].energyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
