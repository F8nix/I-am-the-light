using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightPickupLogical : MonoBehaviour
{
    // Start is called before the first frame update
    
    public LightPickupGraphical lightPickupGraphical;

    public float radius;
    public Collider2D[] lightsToPickUp;

    public LayerMask currencyLayer;
    void Start()
    {
        radius = gameObject.GetComponent<CircleCollider2D>().radius;
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
        lightsToPickUp = Physics2D.OverlapCircleAll(transform.position, radius, currencyLayer);
        if(lightsToPickUp.Length < 1){
            Debug.Log("Nothing to pick up");
        }
        foreach (Collider2D light in lightsToPickUp)
        {
            Destroy(light.gameObject);
            LightSpawnerManager.Instance.currentLight--;
        }
        //DYnamic object pooling
    }
}
