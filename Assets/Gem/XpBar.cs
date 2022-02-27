using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField] int maxXp;
    Slider slider;

    private void Awake()
    {
        Provider.XpBar = this;
        slider = GetComponent<Slider>();
        slider.maxValue = maxXp;
    }

    public void Increase(int xp)
    {
        slider.value += xp;
        if (slider.value == maxXp)
            LevelUp();
    }

    void LevelUp()
    {
        slider.value = 0;
        Provider.UpgradesManager.StartNewUpgradeProcess();
    }
}
