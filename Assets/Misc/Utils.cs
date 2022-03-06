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

    public static float Percentage(float number, float percentage)
    {
        return number / (100 / percentage);
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

    public static GameObject FindNearest(Vector2 point, float radius, LayerMask targetLayer)
    {
        GameObject nearestCandidate = null;
        float shortestDistance = float.PositiveInfinity;
        var nearColliders = Physics2D.OverlapCircleAll(point, radius, targetLayer);
        foreach (Collider2D candidate in nearColliders)
        {
            float distance = Vector2.Distance(point, candidate.gameObject.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestCandidate = candidate.gameObject;
            }
        }
        return nearestCandidate;
    }
}
