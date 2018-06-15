public class DrinkPickUp : ItemPickUp
{
    public override void PickUp(Player player)
    {
        player.GetComponent<Controller>().CmdTakeDrink();
    }
}