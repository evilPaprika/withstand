using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour
{
        
    private static Client instance;
    public static Client Instance => instance ?? (instance = new Client());

    public NetworkClient CurrentCLient { get; private set; }

    private string serverIp;
    private int serverPort;

    // Use this for initialization
    void Start()
    {
        //this.serverIp = serverIp;
        //this.serverPort = serverPort;
        CurrentCLient = new NetworkClient();
        CurrentCLient.Connect(serverIp, serverPort);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
