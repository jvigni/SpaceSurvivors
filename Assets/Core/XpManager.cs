using UnityEngine;
using UnityEngine.UI;

public class XpManager : MonoBehaviour
{
    [SerializeField] Slider xpBarSlider;
    [SerializeField] int baseXpRequirment;
    [SerializeField] int xpIncrementPerLevel;
    
    public int Level = 1;
    int nextLvXpRequired;
    int actualXp;
    
    private void Awake()
    {
        Provider.XpManager = this;
        xpBarSlider.maxValue = nextLvXpRequired;
    }

    public void Increase(int xp)
    {
        actualXp += xp;
        xpBarSlider.value += xp;
        if (actualXp >= nextLvXpRequired)
            LevelUp();
    }

    void LevelUp()
    {
        Level++;
        actualXp = 0;
        xpBarSlider.value = 0;
        nextLvXpRequired += xpIncrementPerLevel;
        xpBarSlider.maxValue = nextLvXpRequired;
        Provider.UpgradesManager.StartNewUpgradeProcess();
    }
}
