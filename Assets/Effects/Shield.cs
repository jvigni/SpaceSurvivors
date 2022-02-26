using UnityEngine;

/*
[CreateAssetMenu(menuName = "Effect/Shield")]
public class Shield : Aura
{
    [SerializeField] float _shieldHealth;

    private float _healthCountdown;

    public override void OnApplied(Character owner, Character caster)
    {
        base.OnApplied(owner, caster);

        _healthCountdown = _shieldHealth;
    }

    public override Damage ModifyIncomingDamage(Damage damage)
    {
        if (_healthCountdown > damage.Amount)
        {
            _healthCountdown -= damage.Amount;
            damage.Amount = 0;
        }
        else
        {
            damage.Amount -= _healthCountdown;
            _healthCountdown = 0;
            IsOver = true;
        }
        return damage;
    }
}*/