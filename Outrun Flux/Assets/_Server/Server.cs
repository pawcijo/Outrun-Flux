using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


public class ServerClient
{
    public int connectionID;
    public Color color;
    public string col;
}


public class Server : MonoBehaviour
{

    public GameObject game1;
    public GameObject game2;
    private ControllerScript controls1;
    private ControllerScript controls2;

    private const int MAX_CONNECTIONS = 5;


    private List<ServerClient> clients = new List<ServerClient>();
    private int port = 5701;

    private int hostID;

    private int reliableChannel;
    private int unreliableChannel;

    private bool isStarted = false;
    private byte error;

    private void Start()
    {
        SetupControlls();
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.Reliable);
        unreliableChannel = cc.AddChannel(QosType.Unreliable);

        HostTopology topo = new HostTopology(cc, MAX_CONNECTIONS);

        hostID = NetworkTransport.AddHost(topo, port, null);

        isStarted = true;
        Debug.Log("SERVER STARTED!");

    }

    public void Update()
    {
        if (!isStarted)
            return;

        int recHostId;
        int connectionId;
        int channelId;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;
        NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {
            case NetworkEventType.ConnectEvent:    //2
                Debug.Log(connectionId + " connected!");
                OnConnection(connectionId);
                break;
            case NetworkEventType.DataEvent:       //3
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                string[] splitData = msg.Split('|');
                //Debug.
                switch (splitData[0])
                {
                    case "CNT":
                        OnControl(connectionId, splitData[1]);
                        break;
                }

                break;
            case NetworkEventType.DisconnectEvent: //4
                Debug.Log(connectionId + " disconnected!");
                break;
        }
    }

    private void OnControl(int cnnID, string data)
    {
        switch (data)
        {
            case "LUP":
                if (cnnID == 1)
                {
                    controls1.LU(true);
                }
                else if (cnnID == 2)
                {
                    controls2.LU(true);
                }
                break;
            case "LUR":
                if (cnnID == 1)
                {
                    controls1.LU(false);
                }
                else if (cnnID == 2)
                {
                    controls2.LU(false);
                }
                break;
            case "RUP":
                if (cnnID == 1)
                {
                    controls1.RU(true);
                }
                else if (cnnID == 2)
                {
                    controls2.RU(true);
                }
                break;
            case "RUR":
                if (cnnID == 1)
                {
                    controls1.RU(false);
                }
                else if (cnnID == 2)
                {
                    controls2.RU(false);
                }
                break;
            case "LDP":
                if (cnnID == 1)
                {
                    controls1.LD(true);
                }
                else if (cnnID == 2)
                {
                    controls2.LD(true);
                }
                break;
            case "LDR":
                if (cnnID == 1)
                {
                    controls1.LD(false);
                }
                else if (cnnID == 2)
                {
                    controls2.LD(false);
                }
                break;
            case "RDP":
                if (cnnID == 1)
                {
                    controls1.RD(true);
                }
                else if (cnnID == 2)
                {
                    controls2.RD(true);
                }
                break;
            case "RDR":
                if (cnnID == 1)
                {
                    controls1.RD(false);
                }
                else if (cnnID == 2)
                {
                    controls2.RD(false);
                }
                break;

        }
    }
    private void OnConnection(int cnnID)
    {
        ServerClient c = new ServerClient();
        c.connectionID = cnnID;
        switch (clients.Count)
        {
            case 0:
                c.color = Color.green;
                c.col = "GREEN";
                break;
            case 1:
                c.color = Color.red;
                c.col = "RED";
                break;
            case 2:
                c.color = Color.magenta;
                c.col = "MAGENTA";
                break;
            case 3:
                c.color = Color.blue;
                c.col = "BLUE";
                break;
            case 4:
                c.color = Color.yellow;
                c.col = "YELLOW";
                break;
        }
        clients.Add(c);

        string msg = "COL|" + c.col;
        Send(msg, reliableChannel, cnnID);
    }

    private void Send(string message, int channelID, int cnnID)
    {
        byte[] msg = System.Text.Encoding.Unicode.GetBytes(message);
        List<ServerClient> c = new List<ServerClient>();
        c.Add(clients.Find(x => x.connectionID == cnnID));
        Send(message, channelID, c);
    }

    private void Send(string message, int channelID, List<ServerClient> c)
    {
        Debug.Log("Sending: " + message);
        byte[] msg = System.Text.Encoding.Unicode.GetBytes(message);
        foreach (ServerClient cl in c)
        {
            NetworkTransport.Send(hostID, cl.connectionID, channelID, msg, message.Length * sizeof(char), out error);
        }
    }

    private void SetupControlls()
    {

        controls1 = game1.GetComponent<ControllerScript>();
        controls2 = game2.GetComponent<ControllerScript>();

    }
}
