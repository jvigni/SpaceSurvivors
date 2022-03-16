public class Stages
{
    public static Stage Stage1()
    {
        return new Stage("Stage I",
            new SpawnEnemyAction(0, .5f, EnemyId.Alien1, .5f),
            new SpawnEnemyAction(.5f, 1, EnemyId.Alien1, 1),
            new SpawnEnemyAction(1, 3, EnemyId.Alien1, 2),

            new SpawnEnemyAction(.5f, 1, EnemyId.Asteroid, 2),
            new SpawnEnemyAction(1, 2, EnemyId.Asteroid, 3),
            new SpawnEnemyAction(2, 3, EnemyId.Asteroid, 4));
    }
}