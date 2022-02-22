public class LaserTurretWeapon : Weapon
{
    public LaserTurretWeapon() : base(.5f) { }

    public override void Trigger()
    {
        Lifeform enemy = Provider.Spaceship.NearestEnemy;
        if(enemy != null)
            enemy.ReceiveDamage(new DmgInfo(10));
    }
}
