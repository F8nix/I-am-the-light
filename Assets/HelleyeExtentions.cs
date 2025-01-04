using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HelleyeExtentions
{
    public static T RandomElement <T>(this IEnumerable<T> enumerable) {
        if(enumerable == null) {
            throw new NullReferenceException("Jakiś error dla pewności");
        }
        int i = UnityEngine.Random.Range(0, enumerable.Count());
        return enumerable.ElementAt(i);
    }
}
