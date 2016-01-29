using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using Leap;


public class ArduinoSerial : Window {

    public static SerialPort ArduinoPort = new SerialPort("COM3", 9600);

    void Start()
    {
        OpenConnection();
    }

    void Update()
    {
        // ArduinoSerial.SendValues();
    }

    public void OpenConnection()
    {
        if (ArduinoPort != null)
        {
            ArduinoPort.Close();
        }
        else
        {
            try
            {
                ArduinoPort.Open();
                ArduinoPort.ReadTimeout = 16;
            }
            catch(System.IO.IOException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }

    void QuitConnection()
    {
        ArduinoPort.Close();
    }

    /*

        Polegar = 0;
        Indicador = 1;
        Médio = 2;
        Anelar = 3;
        Mínimo = 4;
        Palma = 5;    

    */

    public static void SendValues(int indicador)
    {
        string writeString = "";

        if (indicador <= 180)
            writeString = "180";
        else
            writeString = "0";

        if (ArduinoPort.IsOpen)
        {
            try
            {
                ArduinoPort.Write(writeString);
            }
            catch(System.InvalidOperationException)
            {
                //MessageBox.Show("Porta está em uso.");
            }
        }

    }

    internal static void SendValues(long v)
    {
        throw new NotImplementedException();
    }
}
