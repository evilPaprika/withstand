public class BandagesPickUp : ItemPickUp
{
    public override void PickUp(Player player)
    {
        player.GetComponent<Controller>().CmdPickUpBandages();
    }
}
