using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCurrencyOne : MonoBehaviour
{
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        amount = LightSpawnerManager.Instance.lightTypes[0].lightAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
