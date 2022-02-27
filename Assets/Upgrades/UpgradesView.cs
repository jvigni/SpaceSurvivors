using UnityEngine;

public class UpgradesView : MonoBehaviour
{
    [SerializeField] UpgradeView view1;
    [SerializeField] UpgradeView view2;
    [SerializeField] UpgradeView view3;

    private void Awake()
    {
        Provider.UpgradesView = this;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void Init(UpgradeData data1, UpgradeData data2, UpgradeData data3)
    {

    }
}
