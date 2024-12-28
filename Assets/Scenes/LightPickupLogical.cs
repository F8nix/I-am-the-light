using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightPickupLogical : MonoBehaviour
{
    // Start is called before the first frame update
    
    public LightPickupGraphical lightPickupGraphical;
    void Start()
    {
        
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
        Debug.Log("Pick Up!");
    }
}
