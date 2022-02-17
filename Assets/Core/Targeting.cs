using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] float targetFindRange;
    [SerializeField] LayerMask targetLayer;

    public Lifeform GetNearestEnemy()
    {
        var nearerColliders = Physics2D.OverlapCircleAll(transform.position, targetFindRange, targetLayer);
        float shortestDistance = Mathf.Infinity;
        Lifeform result = null;
        foreach (Collider2D colider in nearerColliders)
        {
            float distanceToLifeform = Vector3.Distance(transform.position, colider.transform.position);
            if (distanceToLifeform < shortestDistance)
            {
                shortestDistance = distanceToLifeform;
                result = colider.gameObject.GetComponent<Lifeform>();
            }
        }
        return result;
    }
}
