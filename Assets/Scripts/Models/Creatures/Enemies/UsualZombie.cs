public class UsualZombie : Enemy
{
    protected new virtual void Start()
    {
        Cost = 12;
        Damage = 10;
        Armor = 0;
        MoveSpeed = 1;
        AttackDelay = 1.5f;
        AttackDistance = 1f;
        base.Start();
    }

    protected new virtual void Update()
    {
        base.Update();
    }
}
