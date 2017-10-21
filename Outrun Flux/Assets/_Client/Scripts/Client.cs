using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Client : MonoBehaviour
{

    private const int MAX_CONNECTIONS = 5;


    private int port = 5701;

    private int hostID;

    private int reliableChannel;
    private int unreliableChannel;

    private int connectionID;

    private float connectionTime;
    private bool isConnected = false;
    private bool isStarted = false;
    private byte error;

    public string IPAdress;


    public void Connect()
    {
        IPAdress = GameObject.Find("IPInput").GetComponent<InputField>().text;


        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.Reliable);
        unreliableChannel = cc.AddChannel(QosType.Unreliable);

        HostTopology topo = new HostTopology(cc, MAX_CONNECTIONS);

        hostID = NetworkTransport.AddHost(topo, 0);
        connectionID = NetworkTransport.Connect(hostID, IPAdress, port, 0, out error);

        connectionTime = Time.time;
        isConnected = true;
    }

    private void Update()
    {
        if (!isConnected)
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
            case NetworkEventType.Nothing:         //1
                break;
            case NetworkEventType.ConnectEvent:    //2
                break;
            case NetworkEventType.DataEvent:       //3
                break;
            case NetworkEventType.DisconnectEvent: //4
                break;
        }
    }

    public void LUPress()
    {
        Debug.Log("LU PRESSED!");
    }

    public void LURelease()
    {
        Debug.Log("LU RELEASED!");
    }

    public void RUPress()
    {
        Debug.Log("RU PRESSED!");
    }

    public void RURelease()
    {
        Debug.Log("RU RELEASED!");
    }

    public void LDPress()
    {
        Debug.Log("LD PRESSED!");
    }

    public void LDRelease()
    {
        Debug.Log("LD RELEASED!");
    }

    public void RDPress()
    {
        Debug.Log("RD PRESSED!");
    }

    public void RDRelease()
    {
        Debug.Log("RD RELEASED!");
    }

}
