using System.Collections.Generic;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    internal List<Player> players = new List<Player>();
}
