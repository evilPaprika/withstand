public class FoodPickUp : ItemPickUp
{
    public override void PickUp(Player player)
    {
        player.GetComponent<Controller>().CmdTakeFood();
    }
}
