using UnityEngine;

public class Provider
{
    public static App App;
    public static GameObject Spaceship;
    public static CooldownManager CooldownManager;
    public static UpgradesView UpgradesView;
    public static UpgradesManager UpgradesManager;
    public static XpBar XpBar;
    public static WeaponsManager WeaponsManager;
}

public class WeaponsManager : MonoBehaviour
{
    public HommingMissileLv1 HommingMissileLv1;
    public HommingMissileLv2 HommingMissileLv2;
    public HommingMissileLv3 HommingMissileLv3;
    public HommingMissileLv4 HommingMissileLv4;
    public HommingMissileLv5 HommingMissileLv5;

    private void Awake()
    {
        Provider.WeaponsManager = this;
    }
}
