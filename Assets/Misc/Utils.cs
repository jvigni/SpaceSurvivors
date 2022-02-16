using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    //Return a random float number between min[inclusive] and max[inclusive] (Read Only).
    public static int Rnd(int min, int max)
    {
        return Random.Range(min, max);
    }

    public static bool Chance(int percentage)
    {
        return percentage > Random.Range(0, 99);
    }

    public static void ChangeAlpha(Material material, float newAlpha)
    {
        if (material.HasProperty("_Color"))
        {
            Color newColor = material.color;
            newColor.a = newAlpha;
            material.color = newColor;
        }
    }
}
