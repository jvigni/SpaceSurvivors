using UnityEngine;

public class LaserTurretWeapon : Weapon
{
    public LaserTurretWeapon() : base() { }

    public override void Trigger()
    {
        var target = NearestTarget;
        if (target != null)
            target.GetComponent<Lifeform>().ReceiveDamage(new DmgInfo(10));
    }
}
