﻿using UnityEngine.Networking;

public abstract class Creature : NetworkBehaviour
{
    public int Damage;
    public int Armor;
    public int Health { get { return GetComponent<Health>().CurrentValue; } }
    public float MoveSpeed;
    public float AttackDelay;

    private const int DamageAbsorptionCoef = 3;

    public virtual void ChangeDamage(int amount)
    {
        Damage += amount;
    }

    public virtual void ChangeArmor(int amount)
    {
        Armor += amount;
    }

    public virtual void ChangeMoveSpeed(int amount)
    {
        MoveSpeed += amount;
    }

    public virtual void ChangeAttackDelay(int amount)
    {
        AttackDelay += amount;
    }

    public virtual bool IsDead()
    {
        return Health <= 0;
    }
    
    public virtual void TakeDamage(int amount, Creature creature)
    {
        creature.GetDamage(amount);
    }

    public virtual void GetDamage(int amount)
    {
        GetComponentInChildren<Health>().DecreaseLevel(amount - Armor * DamageAbsorptionCoef);
    }

    public virtual void AddHealth(int amount)
    {
        GetComponentInChildren<Health>().IncreaseLevel(amount);
    }

    public virtual void SetFullHealth()
    {
        GetComponentInChildren<Health>().SetFull();
    }
}