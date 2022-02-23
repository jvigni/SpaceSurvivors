using UnityEngine;

public class SpaceshipLevelSystem : MonoBehaviour
{
    public int Experience { get; private set; }

    public void GainExperience(int experience)
    {
        Experience += experience;
    }
}
