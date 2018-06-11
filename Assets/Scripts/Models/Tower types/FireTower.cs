public class FireTower : Tower
{
    protected new virtual void Start()
    {
        base.Start();
        Cost = 80;
        Health = 100;
        AttackDelay = 3f;
        Damage = 64;
        Armor = 2;
        Effect = Effect.Burn; // there is a 10% chance to kill in one shot
    }

    protected new virtual void Update()
    {
        base.Update();
    }
}