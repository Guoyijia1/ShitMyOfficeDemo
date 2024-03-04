using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;

//09/24/2022 updated

public class SerialPortConnect : MonoBehaviour
{
    public String portName = "COM3";  // use the port name for your Arduino, such as /dev/tty.usbmodem1411 for Mac or COM3 for PC 

    private SerialPort serialPort = null;
    private int baudRate = 9600;  // match your rate from your serial in Arduino
    private int readTimeOut = 100;
    public float speedFactor = 15.0f;

    public bool moveLeft;
    public bool moveRight;
    public bool jumpNow;

    private string serialInput;
    bool programActive = true;
    Thread thread;

    public float playerDiff1, playerDiff2;



    // Start is called before the first frame update
    void Start()
    {
        try
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.RtsEnable = true;
            serialPort.ReadTimeout = readTimeOut;
            serialPort.Open();

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        thread = new Thread(new ThreadStart(ProcessData));  // serial events are now handled in a separate thread
        thread.Start();

    }

    void ProcessData()
    {
        //Debug.Log("Thread: Start");
        while (programActive)
        {
            try
            {
                serialInput = serialPort.ReadLine();
            }
            catch (TimeoutException)
            {

            }
        }
        //Debug.Log("Thread: Stop");
    }

    // Update is called once per frame
    void Update()
    {
        if (serialInput != null)
        {
            string[] strEul = serialInput.Split(',');
            //Debug.LogWarning(serialInput);
            if (strEul.Length == 2) // only uses the parsed data if every input expected has been received. In this case, three inputs consisting of a button (0 or 1) and two analog values between 0 and 1023
            {
                //Debug.Log(strEul[1]);

                playerDiff1 = float.Parse(strEul[0]);
                playerDiff2 = float.Parse(strEul[1]);

                //transform.rotation = new Quaternion(-qy, -qz, qx, qw);

            } 
        }

        //transform.Translate(transform.forward * Time.deltaTime * speedFactor, Space.World);
    }

}
