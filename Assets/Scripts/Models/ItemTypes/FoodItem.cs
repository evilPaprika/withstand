public class FoodItem : Item
{
    public int FoodAmount = 50;

    public override void BeUsed()
    {
        // здесь получить сытость игрока
        // GetComponent<Player>().CurrentSatiety += FoodAmount;
    }
}
