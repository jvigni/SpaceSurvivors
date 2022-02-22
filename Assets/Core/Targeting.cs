using System.Collections;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] float findRange;
    [SerializeField] float refreshTimeInSec;
    [SerializeField] LayerMask targetLayer;
    public GameObject Target { get; private set; }

    private void Start()
    {
        StartCoroutine(RefreshTargetCoroutine());
    }

    IEnumerator RefreshTargetCoroutine()
    {
        var wfs = new WaitForSecondsRealtime(refreshTimeInSec);
        while (true)
        {
            yield return wfs;
            Target = Utils.FindNearest(transform.position, findRange, targetLayer);
        }
    }
}
