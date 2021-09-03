using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothSample : MonoBehaviour
{
    SerialManager serialReceiver;

    public string port = "COM8";
    public int baudrate = 115200;

    public string message = "0";

    void Start()
    {
        serialReceiver = new SerialManager(port, baudrate);
        serialReceiver.callback = GetData;
    }

    [ContextMenu("Send")]
    void Send()
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
