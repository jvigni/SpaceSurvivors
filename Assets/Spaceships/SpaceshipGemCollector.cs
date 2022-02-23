using UnityEngine;

public class SpaceshipGemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gem = collision.gameObject.GetComponent<Gem>();
        if (gem != null)
            gem.GetPicked();
    }
}
