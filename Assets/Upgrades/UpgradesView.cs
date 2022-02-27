using System;
using UnityEngine;

public class UpgradesView : MonoBehaviour
{
    [SerializeField] UpgradeView view1;
    [SerializeField] UpgradeView view2;
    [SerializeField] UpgradeView view3;
    public event Action<Upgrade> OnUpgradePicked;

    public void Show(UpgradeData data1, UpgradeData data2, UpgradeData data3)
    {
        gameObject.SetActive(true);
        //TODO
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
