using System.Collections;
using UnityEngine;

public class FlamethrowerWeapon : Weapon
{
    [SerializeField] float firingSeconds;
    [SerializeField] DmgInfo damage;
    [SerializeField] Effect burningEffect;
    bool firing;

    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("T1","D1"),
        new WeaponLevelData("T2","D2"),
        new WeaponLevelData("T3","D3"),
        new WeaponLevelData("T4","D4"),
        new WeaponLevelData("T5","D5"),
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

    public override void Trigger()
    {
        StartCoroutine(FlamethrowerRoutine());
    }

    IEnumerator FlamethrowerRoutine()
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
