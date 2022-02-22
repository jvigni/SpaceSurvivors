using UnityEngine;

public class LaserTurretWeapon : Weapon
{
    public LaserTurretWeapon() : base() { }

    public override void Trigger()
    {
        GameObject enemy = Provider.Spaceship.GetComponent<Targeting>().Target;
        if(enemy != null)
            enemy.GetComponent<Lifeform>().ReceiveDamage(new DmgInfo(10));
    }
}
