using System.Collections;
using UnityEngine;

public class FlamethrowerWeapon : Weapon
{
    [SerializeField] float firingSeconds;
    [SerializeField] DmgInfo damage;
    [SerializeField] Effect burningEffect;
    bool firing;

    public override WeaponID ID => WeaponID.Flamethrower;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>Flamethrower","Burn them all!"),
        new WeaponLevelData("Flamethrower II","TODO"),
        new WeaponLevelData("Flamethrower III","TODO"),
        new WeaponLevelData("Flamethrower IV","TODO"),
        new WeaponLevelData("Flamethrower V","TODO"),
    };

    private void Start()
    {
        GetComponent<ParticleSystem>().Stop(); //No puedo arrancarlo apagado desde el inspector
    }

    private void Update()
    {
        if (!firing) return;

        transform.right = Provider.Spaceship.transform.up;

        /*
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if(target)
            transform.right = target.transform.position - transform.position;
        */
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Enemy")) return;

        var lifeform = collision.gameObject.GetComponent<Lifeform>();
        if (lifeform)
        {
            lifeform.ReceiveDamage(damage);
            //lifeForm.ApplyEffect(burningEffect, owner);
        }
    }

    public override IEnumerator OnCooldownFinish()
    {
        firing = true;
        GetComponent<ParticleSystem>().Play();
        GetComponent<PolygonCollider2D>().enabled = true;

        yield return new WaitForSeconds(firingSeconds);

        firing = false;
        GetComponent<ParticleSystem>().Stop();
        GetComponent<PolygonCollider2D>().enabled = false;
    }
}
