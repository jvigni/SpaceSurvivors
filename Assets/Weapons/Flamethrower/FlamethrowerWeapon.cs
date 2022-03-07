using System.Collections;
using UnityEngine;

public class FlamethrowerWeapon : Weapon
{
    [SerializeField] float baseDamage;
    [SerializeField] float baseFiringSeconds;
    [SerializeField] float lv2DamageIncrease;
    [SerializeField] float lv3ExtraFiringSeconds;
    [SerializeField] float lv4CooldownReduction;
    float damage;
    float firingSeconds;
    bool firing;

    public override WeaponID ID => WeaponID.Flamethrower;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>Flamethrower","Burn them all!"),
        new WeaponLevelData("Flamethrower II","Increase Damage"),
        new WeaponLevelData("Flamethrower III","Bigger Fuel Tank"),
        new WeaponLevelData("Flamethrower IV","Faster Reloading"),
        //new WeaponLevelData("Flamethrower V","TODO"),
    };

    private void Start()
    {
        GetComponent<ParticleSystem>().Stop(); //No puedo arrancarlo apagado desde el inspector
        damage = baseDamage;
        firingSeconds = baseFiringSeconds;
    }

    private void Update()
    {
        if (!firing) return;
        transform.right = Provider.Spaceship.transform.up;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Enemy")) return;

        var lifeform = collision.gameObject.GetComponent<Lifeform>();
        if (lifeform)
            lifeform.ReceiveDamage(new DmgInfo(damage));
    }

    public override IEnumerator DoOnCooldownFinish()
    {
        firing = true;
        GetComponent<ParticleSystem>().Play();
        GetComponent<PolygonCollider2D>().enabled = true;

        yield return new WaitForSeconds(firingSeconds);

        firing = false;
        GetComponent<ParticleSystem>().Stop();
        GetComponent<PolygonCollider2D>().enabled = false;
    }

    protected override void DoOnLevelUp(int level)
    {
        if (level == 2)
            damage += lv2DamageIncrease;

        if (level == 3)
            firingSeconds += lv3ExtraFiringSeconds;

        if (level == 4)
            Cooldown.Seconds -= lv4CooldownReduction;
    }
}
