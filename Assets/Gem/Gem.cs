using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] float gemMovementSpeed;
    [SerializeField] float minDistanceToConsume;
    int experience;
    bool picked;

    public void GetPicked()
    {
        picked = true;
    }

    void Consume()
    {
        Provider.XpBar.Increase(1);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!picked) 
            return;

        gemMovementSpeed += .1f;
        var directionToShip = Provider.Spaceship.transform.position - transform.position;
        var movement = gemMovementSpeed * directionToShip * Time.deltaTime;
        transform.position += movement;

        var distanceToShip = Vector2.Distance(Provider.Spaceship.transform.position, transform.position);
        if (distanceToShip <= minDistanceToConsume)
            Consume();
    }

    public void Init(int experience)
    {
        this.experience = experience;
    }
}
