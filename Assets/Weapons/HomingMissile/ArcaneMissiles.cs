using UnityEngine;

public class ArcaneMissiles : Spell {
    
    [SerializeField] float secondsBetweenShoots;
    [SerializeField] Projectile projectile;

    bool active;
    Cooldown cooldownBetweenShoots;
    Resource mana;
    Animator animator;

    void Start()
    {
        mana = owner.GetComponent<Caster>().Mana;
        animator = owner.GetComponent<Animator>();
        cooldownBetweenShoots = new Cooldown(secondsBetweenShoots);
    }

    void Update()
    {
        if (!active)
            return;

        if (!mana.Has(manaCost))
            active = false;

        mana.Decrease(manaCost);
        animator.SetBool("handsUp", true);
        if (cooldownBetweenShoots.IsReady())
        {
            Shoot(owner);
            cooldownBetweenShoots.Start();
        }
    }

    public override void OnTrigger()
    {
        active = true;
    }

    protected override void OnRelease()
    {
        base.OnRelease();
        active = false;
    }

    void Shoot(LifeForm actor)
    {
        Quaternion rotation = Random.rotation;
        rotation.y = 0f;
        rotation.x = 0f;
        //Quaternion rotation = Quaternion.Euler(0,0,Random.Range(45,-45));

        Vector2 spawnPosition = actor.transform.position;
        projectile.build(spawnPosition, rotation, actor);
    }
}