using System.Collections;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] float findRange;
    [SerializeField] float refreshTimeInSec;
    [SerializeField] LayerMask targetLayer;

    public GameObject Target
    {
        get
        {
            if (Target == null)
                UpdateTarget();

            return Target;
        }
        private set { Target = value; }
    }

    private void Start()
    {
        RefreshTargetCoroutine();
    }

    IEnumerator RefreshTargetCoroutine()
    {
        var wfs = new WaitForSecondsRealtime(refreshTimeInSec);
        while (true)
        {
            yield return wfs;
            UpdateTarget();
        }
    }

    public void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject result = null;
        var nearColliders = Physics2D.OverlapCircleAll(transform.position, findRange, targetLayer);

        foreach (Collider2D colider in nearColliders)
        {
            float distance = Vector3.Distance(transform.position, colider.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                result = colider.gameObject;
            }
        }
        Target = result;
    }
}
