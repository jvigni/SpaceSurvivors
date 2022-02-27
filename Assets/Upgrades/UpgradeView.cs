using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleTMP;
    [SerializeField] TextMeshProUGUI descriptionTMP;
    [SerializeField] Image iconIMG;
    [SerializeField] GameObject selected;
    Upgrade upgrade;

    public void Init(UpgradeData data)
    {
        upgrade = data.upgrade;
        titleTMP.text = data.title;
        descriptionTMP.text = data.description;
        iconIMG.sprite = data.icon;
    }
}
