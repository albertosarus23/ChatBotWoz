using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using TMPro;
using UnityEngine.UI;
public class Echo : MonoBehaviour
{
    private Socket _socket;
    //UGUI
    public TMP_InputField InputField;
    public TMP_Text Text;

    private byte[] readBuff = new byte[1024];
    private string recvStr = "";

    // Connection callback
    
    // way to connect
    public void Connection()
    {
        //Socket
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //Connect
        //_socket.Connect("127.0.0.1", 3000);
        _socket.BeginConnect("127.0.0.1", 3000, ConnectCallback, _socket);
    }

    public void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            Socket _socket = (Socket) ar.AsyncState;
            _socket.EndConnect(ar);
            Debug.Log("Sock connect success");
            _socket.BeginReceive(readBuff, 0, 1024, 0, ReceiveCallback, _socket);
        }
        catch(SocketException ex)
        {
            Debug.Log("Socket Connect fail" + ex.ToString());
        }
    }

    // receive callback
    public void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            Socket _socket = (Socket) ar.AsyncState;
            int count = _socket.EndReceive(ar);
            string s = System.Text.Encoding.Default.GetString(readBuff, 0, count);
            recvStr = s + "\n" + recvStr;
            _socket.BeginReceive(readBuff, 0, 1024, 0, ReceiveCallback, _socket);
        }
        catch (Exception ex)
        {
            Debug.Log("Socket connect fail"+ex.ToString());
        }
    }
    // way to send
    public void Send()
    {
        //Send
        string sendStr = InputField.text;
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr);
        //_socket.Send(sendBytes);
        _socket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallback, _socket);
        // // //Recv
        // byte[] readBuff = new byte[1024];
        // int count = _socket.Receive(readBuff);
        // string recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count);
        // Text.text = recvStr;
        // //Close
        // _socket.Close();
    }

    public void SendCallback(IAsyncResult ar)
    {
        try
        {
            Socket _socket = (Socket) ar.AsyncState;
            int count = _socket.EndSend(ar);
            Debug.Log("Socket Send success"+count);
        }
        catch (Exception ex)
        {
            Debug.Log("Socket failed "+ex.ToString());
        }
    }

    public void Update()
    {
        Text.text = recvStr;
    }
}
