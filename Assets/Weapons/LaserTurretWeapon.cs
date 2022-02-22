public class LaserTurretWeapon : Weapon
{
    public LaserTurretWeapon() : base() { }

    public override void Trigger()
    {
        Lifeform enemy = Provider.Spaceship.NearestEnemy;
        if(enemy != null)
            enemy.ReceiveDamage(new DmgInfo(10));
    }
}
