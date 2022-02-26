using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public event Action<Effect> OnEffectApplied;
    public event Action<Effect> OnEffectRemoved;
    public List<Effect> Effects { get; private set; }
    Lifeform effectsOwner;

    public EffectsManager(Lifeform effectsOwner)
    {
        Effects = new List<Effect>();
        this.effectsOwner = effectsOwner;
    }

    public T GetEffect<T>() where T : Effect
    {
        return (T)Effects.Where(effect => effect is T).FirstOrDefault();
    }

    public Effect GetEffect(EffectID id)
    {
        return Effects.Where(effect => effect.ID == id).FirstOrDefault();
    }

    public bool HasEffect(EffectID id)
    {
        foreach (Effect effect in Effects)
        {
            if (effect.ID == id)
                return true;
        }
        return false;
    }

    public void ApplyEffect(Effect originalEffect, Lifeform caster)
    {
        Effect effectClone = originalEffect.DeepClone();
        var existingEffect = GetEffect(effectClone.ID);

        if (effectClone.AplicationBehaviour == EffectAplicationBehaviour.Stackeable)
        {
            if (existingEffect != null)
                existingEffect.Stack(effectClone);
            else
                ApplyNewEffect(effectClone, caster);
        }

        if (effectClone.AplicationBehaviour == EffectAplicationBehaviour.Unique)
        {
            if (existingEffect != null)
                RemoveEffect(effectClone.ID);

            ApplyNewEffect(effectClone, caster);
        }
    }

    public void RemoveEffect(EffectID id)
    {
        var desiredEffect = Effects.Where(effect => effect.ID == id).FirstOrDefault();
        if (desiredEffect != null)
            RemoveEffect(desiredEffect);
    }

    public void RemoveAllEffects()
    {
        foreach (Effect effect in Effects.ToList())
            RemoveEffect(effect);
    }

    void ApplyNewEffect(Effect effect, Lifeform caster)
    {
        Effects.Add(effect);
        effect.Owner = effectsOwner;
        effect.Caster = caster;
        effect.OnExpire += RemoveEffect;

        OnEffectApplied?.Invoke(effect);
    }

    void RemoveEffect(Effect effect)
    {
        OnEffectRemoved?.Invoke(effect);
        Effects.Remove(effect);
    }
}