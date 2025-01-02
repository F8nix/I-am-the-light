using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightPickupGraphical : MonoBehaviour
{
    public event Action onDissappearence;
    public void PickupLight() {
        onDissappearence?.Invoke();
    }
}
