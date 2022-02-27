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

    public void Init(UpgradeData data)
    {
        Upgrade = data.upgrade;
        titleTMP.text = data.title;
        descriptionTMP.text = data.description;
        iconIMG.sprite = data.icon;
    }

    public void SetSelected(bool b)
    {
        selected.SetActive(b);
    }
}
