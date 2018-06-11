public class ShootingTower : Tower
{
    protected new virtual void Start()
    {
        base.Start();
        Cost = 55;
        Health = 80;
        AttackDelay = 10;
        Damage = 10;
        Armor = 1;
        Effect = Effect.Bleeding; // lose 3 HP per second for 5 seconds
    }

    protected new virtual void Update()
    {
        base.Update();
    }
}
