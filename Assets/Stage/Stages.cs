public class Stages
{
    public static Stage Stage1()
    {
        return new Stage("Stage I",
            new IncreaseSpawnerAction(0, EnemyId.Alien1, 7),
            new IncreaseSpawnerAction(1, EnemyId.Alien1, 15),
            new IncreaseSpawnerAction(2, EnemyId.Alien1, 30),
            new IncreaseSpawnerAction(3, EnemyId.Alien1, 55),
            new IncreaseSpawnerAction(4, EnemyId.Alien1, 100),
            new IncreaseSpawnerAction(4, EnemyId.Alien1, 200),

            new IncreaseSpawnerAction(1f, EnemyId.Asteroid, 2),
            new IncreaseSpawnerAction(2f, EnemyId.Asteroid, 4),
            new IncreaseSpawnerAction(3, EnemyId.Asteroid, 10));
    }
}