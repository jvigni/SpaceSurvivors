public class LaserTurretWeapon : Weapon
{
    public LaserTurretWeapon() : base(.3f) { }

    public override void Trigger()
    {
        Lifeform enemy = Provider.Spaceship.NearestEnemy;
        enemy.ReceiveDamage(1f);
    }
}
