using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Client : MonoBehaviour
{

    private Color color;

    public Button LUButton;
    public Button LDButton;
    public Button RUButton;
    public Button RDButton;
    public Text connectionText;
    private string col;
    /// <summary>
    /// Network Stuff
    /// </summary>

    private const int MAX_CONNECTIONS = 5;


    private int port = 5701;

    private int hostID;

    private int reliableChannel;
    private int unreliableChannel;

    private int ourClientID;
    private int connectionID;

    private float connectionTime;
    private bool isConnected = false;
    private bool isStarted = false;
    private byte error;

    public string IPAdress;


    private void setColor()
    {
        //Changes the button's Normal color to the new color.
        ColorBlock cb = LUButton.colors;
        cb.normalColor = color;
        cb.highlightedColor = color;
        LUButton.colors = cb;
        LDButton.colors = cb;
        RUButton.colors = cb;
        RDButton.colors = cb;
    }

    public void Connect()
    {
        if (isConnected)
            return;

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
            case NetworkEventType.ConnectEvent:    //2

                break;
            case NetworkEventType.DataEvent:       //3
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                string[] splitData = msg.Split('|');

                switch (splitData[0])
                {
                    case "COL":
                        OnColor(splitData[1]);
                        break;
                    case "CNN":
                        break;
                    case "DC":
                        break;

                    default:
                        Debug.Log("invalid message " + msg);
                        break;
                }
                break;
            case NetworkEventType.DisconnectEvent: //4

                break;

        }
    }

    private void OnColor(string data)
    {
        switch (data)
        {
            case "GREEN":
                color = Color.green;
                col = "GREEN";
                break;
            case "RED":
                color = Color.red;
                col = "RED";
                break;
            case "MAGENTA":
                color = Color.magenta;
                col = "MAGENTA";
                break;
            case "BLUE":
                color = Color.blue;
                col = "BLUE";
                break;
            case "YELLOW":
                color = Color.yellow;
                col = "YELLOW";
                break;
        }
        setColor();
        connectionText.text = "You are " + col;
    }
    
    private void Send(string message, int channelID)
    {
        Debug.Log("Sending: " + message);
        byte[] msg = System.Text.Encoding.Unicode.GetBytes(message);
        NetworkTransport.Send(hostID, connectionID, channelID, msg, message.Length * sizeof(char), out error);
    }

    public void LUPress()
    {
        Debug.Log("LU PRESSED!");
        Send("CNT|LUP", reliableChannel);
    }

    public void LURelease()
    {
        Debug.Log("LU RELEASED!");
        Send("CNT|LUR", reliableChannel);
    }

    public void RUPress()
    {
        Debug.Log("RU PRESSED!");
        Send("CNT|RUP", reliableChannel);
    }

    public void RURelease()
    {
        Debug.Log("RU RELEASED!");
        Send("CNT|RUR", reliableChannel);
    }

    public void LDPress()
    {
        Debug.Log("LD PRESSED!");
        Send("CNT|LDP", reliableChannel);
    }

    public void LDRelease()
    {
        Debug.Log("LD RELEASED!");
        Send("CNT|LDR", reliableChannel);
    }

    public void RDPress()
    {
        Debug.Log("RD PRESSED!");
        Send("CNT|RDP", reliableChannel);
    }

    public void RDRelease()
    {
        Debug.Log("RD RELEASED!");
        Send("CNT|RDR", reliableChannel);
    }

}
