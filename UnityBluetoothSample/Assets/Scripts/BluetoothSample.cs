using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothSample : MonoBehaviour
{
    SerialServiceManager serialReceiver;

    public string port = "COM8";
    public int baudrate = 115200;

    public string message { get; set; } = "0";

    void Start()
    {
        serialReceiver = new SerialServiceManager(port, baudrate);
        serialReceiver.callback = GetData;
    }

    [ContextMenu("Send")]
    public void Send()
    {
        serialReceiver.SendMessage(message);
    }

    private void GetData()
    {
        string data = serialReceiver.stringData;
        Debug.Log("[Log]" + data);
    }

    private void OnDisable()
    {
        if (serialReceiver != null)
            serialReceiver.Dispose();
    }
}
