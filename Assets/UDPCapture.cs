using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPCapture : MonoBehaviour
{
    public int Port;
    private UdpClient _ReceiveClient;
    private Thread _ReceiveThread;
    public interface IReceiverObserver
    {
        void OnDataReceived(double[] val);
    }
    private IReceiverObserver _Observer;

    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize objects.
    /// </summary>
    public void Initialize()
    {
        // Receive
        _ReceiveThread = new Thread(
            new ThreadStart(ReceiveData));
        _ReceiveThread.IsBackground = true;
        _ReceiveThread.Start();
    }

    public void SetObserver(IReceiverObserver observer)
    {
        _Observer = observer;
    }

    /// <summary>
    /// Receive data with pooling.
    /// </summary>
    private void ReceiveData()
    {
        _ReceiveClient = new UdpClient(Port);

        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = _ReceiveClient.Receive(ref anyIP);

                double[] values = new double[data.Length / 8];
                Buffer.BlockCopy(data, 0, values, 0, values.Length * 8);

                if (_Observer != null)
                    _Observer.OnDataReceived(values);

                Debug.Log(">>>>");
            }
            catch (Exception err)
            {
                Debug.Log("<color=red>" + err.Message + "</color>");
            }
        }
    }

    /// <summary>
    /// Deinitialize everything on quiting the application.Or you might get error in restart.
    /// </summary>
    private void OnApplicationQuit()
    {
        try
        {
            _ReceiveThread.Abort();
            _ReceiveThread = null;
            _ReceiveClient.Close();
        }
        catch (Exception err)
        {
            Debug.Log("<color=red>" + err.Message + "</color>");
        }
    }
}