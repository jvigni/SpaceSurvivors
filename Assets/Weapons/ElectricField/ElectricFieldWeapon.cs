using System.Collections;
using UnityEngine;

public class ElectricFieldWeapon : Weapon
{
    [SerializeField] ParticleSystem FXPrefab;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float radius;
    [SerializeField] int damage;
    [SerializeField] int lv2DmgIncrease;
    [SerializeField] float lv3RadiusIncrease;
    [SerializeField] float lv4CooldownRed;

    ParticleSystem ps;

    public override WeaponID ID => WeaponID.ElectricField;

    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("WEAPON: Electric Field I", "Electrify nearby enemies"),
        new WeaponLevelData("Electric Field II", "Increased damage"),
        new WeaponLevelData("Electric Field III", "Increased radius"),
        new WeaponLevelData("Electric Field IV", "Faster shocks")
    };

    public override void OnTurnOn()
    {
        ps = Instantiate(FXPrefab);
        var shape = ps.shape;
        shape.radius = radius;
    }

    private void Update()
    {
        ps.transform.position = Provider.Spaceship.transform.position;
    }

    public override IEnumerator DoOnCooldownFinish()
    {
        var nearColliders = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        foreach(Collider2D collider in nearColliders)
            collider.GetComponent<Lifeform>().ReceiveDamage(damage);

        yield return null;
    }

    protected override void DoOnLevelUp(int level)
    {
        if (level == 2)
            damage += lv2DmgIncrease;
        
        if (level == 3)
        {
            radius += lv3RadiusIncrease;
            var shape = ps.shape;
            shape.radius += lv3RadiusIncrease;
        }

        if (level == 4)
            Cooldown.Seconds -= lv4CooldownRed;
    }
}
