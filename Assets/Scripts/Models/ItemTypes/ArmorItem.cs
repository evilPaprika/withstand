public class ArmorItem : Item
{
    public int Armor = 1;

    public override void BeUsed()
    {
        // здесь получить армор игрока
        // GetComponent<Player>().Armor += Armor;
    }
}
