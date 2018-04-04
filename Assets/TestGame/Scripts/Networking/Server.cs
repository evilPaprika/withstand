using System;
using UnityEngine;
using UnityEngine.Networking;

public class Server
{

    private static Server _instance;

    public static Server Instance => _instance ?? (_instance = new Server());

    private User _currentUser;
    public User CurrentUser => _currentUser;

    // Use this for initialization
    void Start(int port)
    {
        _currentUser = new User();
        NetworkServer.Listen(port);
        NetworkServer.maxDelay = 0;
        RegisterServerHandlers();
    }

    public void ShutDown()
    {
        NetworkServer.Shutdown();
    }

    private void RegisterServerHandlers()
    {
        NetworkServer.RegisterHandler(MsgType.Connect, OnConnect);
        //NetworkServer.RegisterHandler(MyMsgType.C);
    }

    private void OnConnect(NetworkMessage netMsg)
    {
        Debug.Log("Connect: " + netMsg.conn.address);
        var connectionId = netMsg.conn.connectionId;
        if (NetworkServer.connections.Count > Constants.MaxPlayersCount)
        {
            // нельзя подключиться к игре более чем MaxPlayersCount игрокам
            //SendPlayerID(connectionId, -1); 
        }
        else
        {
            int index = UnityEngine.Random.Range(0, Constants.PlayersIDs.Count);
        }
    }

    private void SendPlayerID(int connId, int playerId)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
