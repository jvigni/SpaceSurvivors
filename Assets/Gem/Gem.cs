using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] float gemMovementSpeed;
    [SerializeField] float minDistanceToConsume;
    bool picked;

    public void GetPicked()
    {
        picked = true;
    }

    void Consume()
    {
        Debug.Log("+1");
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!picked) 
            return;

        var directionToShip = Provider.Spaceship.transform.position - transform.position;
        var movement = gemMovementSpeed * directionToShip * Time.deltaTime;
        transform.position += movement;

        var distanceToShip = Vector2.Distance(Provider.Spaceship.transform.position, transform.position);
        if (distanceToShip <= minDistanceToConsume)
            Consume();
    }
}
