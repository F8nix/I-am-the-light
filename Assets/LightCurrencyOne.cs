using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCurrencyOne : MonoBehaviour
{
    public int lightAmount;
    public float energyAmount;
    // Start is called before the first frame update
    void Start()
    {
        lightAmount = LightSpawnerManager.Instance.lightTypes[0].lightAmount;
        energyAmount = LightSpawnerManager.Instance.lightTypes[0].energyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
