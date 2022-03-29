using System.Collections;
using UnityEngine;

public class ElectricFieldWeapon : Weapon
{
    [SerializeField] ParticleSystem FXPrefab;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float radius;
    [SerializeField] int damage;
    ParticleSystem ps;

    public override WeaponID ID => WeaponID.ElectricField;

    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("WEAPON: Electric Field I", "Electrify nearby enemies")
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
}
