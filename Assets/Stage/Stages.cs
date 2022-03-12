public class Stages
{
    public static Stage Stage1()
    {
        return new Stage("Stage I",
            new SpawnEnemyAction(0, 1, EnemyID.Alien1, .5f),
            new SpawnEnemyAction(1, 2, EnemyID.Alien1, 1),
            new SpawnEnemyAction(2, 3, EnemyID.Alien1, 2),

            new SpawnEnemyAction(1, 2, EnemyID.Asteroid, 3),
            new SpawnEnemyAction(2, 3, EnemyID.Asteroid, 2),
            new SpawnEnemyAction(3, 4, EnemyID.Asteroid, 1));
    }
}