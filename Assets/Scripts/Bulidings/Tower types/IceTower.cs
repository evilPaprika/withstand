public class IceTower : Tower
{
    protected new virtual void Start()
    {
        base.Start();
        Cost = 60;
        Health = 100;
        AttackDelay = 6;
        Damage = 12;
        Armor = 2;
        Effect = Effect.Frostbite; // reduce attack rate on 3(?) and move speed on 3(?)
    }

    protected new virtual void Update()
    {
        base.Update();
    }
}