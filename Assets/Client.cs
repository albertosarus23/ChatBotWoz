using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.UI;
using TMPro;

public class Client : MonoBehaviour
{
    private Socket _socket;
    [SerializeField] TextMeshProUGUI recvBox;
    // [SerializeField] TextMeshProUGUI textBox;
    // use middle ware to access info
    [SerializeField] private MiddleWare _middleWare;
    
    // receive buff area
    private byte[] _readBuff = new byte[1024];
    private string _recvStr = "";

    
    public void Connection()
    {
        //Socket
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // async connect
        _socket.BeginConnect("127.0.0.1", 3000,ConnectCallback,_socket);
        Debug.Log("Connect");
    }

    public void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            Socket socket = (Socket) ar.AsyncState;
            socket.EndConnect(ar);
            // Will terminate in the other thread and return to main thread
            Debug.Log("Socket connect Succ");
            socket.BeginReceive(_readBuff, 0, 1024, 0, ReceiveCallback, socket);
        }
        catch(SocketException ex)
        {
            Debug.Log("Socket Connect fail" + ex.ToString());
        }
    }

    public void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            Socket socket = (Socket) ar.AsyncState;
            int count = socket.EndReceive(ar);
            // the count here is multiple, try to only receive one.
            _recvStr = System.Text.Encoding.Default.GetString(_readBuff, 0, count);
            _middleWare.recvFlag = true;
            Debug.Log(_recvStr);
            socket.BeginReceive(_readBuff, 0, 1024, 0, ReceiveCallback, socket);
        }
        catch (SocketException e)
        {
            Debug.Log("Socket Receive fail" + e.ToString());
        }
    }
    public void Send()
    {
        Debug.Log("Send");
        string sendStr = "user context delivered";
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr);
        _socket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallback, _socket);
    }

    public void SendCallback(IAsyncResult ar)
    {
        try
        {
            Socket socket = (Socket) ar.AsyncState;
            int count = socket.EndSend(ar);
            Debug.Log("Socket send succ" + count);
        }
        catch (SocketException ex)
        {
            Debug.Log("Socket Send fail"+ex.ToString());
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Connection();
    }

    // Update is called once per frame
    void Update()
    {
        _middleWare.Updaterecv(_recvStr);
    }
}
