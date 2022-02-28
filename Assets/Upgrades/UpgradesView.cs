using System;
using UnityEngine;

public class UpgradesView : MonoBehaviour
{
    [SerializeField] UpgradeView[] upgradeViews;
    public event Action<UpgradeData> OnUpgradePicked;
    int selectedIndex;

    public void Show(UpgradeData[] upgradeData)
    {
        for (int i = 0; i < upgradeViews.Length; i++)
            upgradeViews[i].Init(upgradeData[i]);

        Select(0);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        var upInput = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        if (upInput && selectedIndex != 0)
            Select(selectedIndex - 1);

        var downInput = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        if (downInput && selectedIndex != 2)
            Select(selectedIndex + 1);
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnUpgradePicked?.Invoke(upgradeViews[selectedIndex].Data);
            Hide();
        }
    }

    void Select(int index)
    {
        upgradeViews[selectedIndex].SetSelected(false);

        selectedIndex = index;
        upgradeViews[index].SetSelected(true);
    }
}
