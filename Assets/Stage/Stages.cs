public class Stages
{
    public static Stage Stage1()
    {
        return new Stage("Stage I",
            new IncreaseSpawnerAction(0, EnemyId.Alien1, 3),
            new IncreaseSpawnerAction(.5f, EnemyId.Alien1, 5),
            new IncreaseSpawnerAction(1, EnemyId.Alien1, 10),

            new IncreaseSpawnerAction(0f, EnemyId.Asteroid, 2),
            new IncreaseSpawnerAction(0.3f, EnemyId.Asteroid, 4),
            new IncreaseSpawnerAction(2, EnemyId.Asteroid, 8));
    }
}