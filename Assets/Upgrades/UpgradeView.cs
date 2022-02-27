using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Image icon;
    Upgrade upgrade;

    public void Init(Upgrade upgrade)
    {
        this.upgrade = upgrade;
    }
}
