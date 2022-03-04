using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleTMP;
    [SerializeField] TextMeshProUGUI descriptionTMP;
    [SerializeField] Image iconIMG;
    [SerializeField] GameObject selected;
    public Upgrade Upgrade;

    public void Init(Upgrade upgrade)
    {
        Upgrade = upgrade;
        titleTMP.text = upgrade.Title;
        descriptionTMP.text = upgrade.Description;
        iconIMG.sprite = upgrade.Icon;
    }

    public void SetSelected(bool b)
    {
        selected.SetActive(b);
    }
}
