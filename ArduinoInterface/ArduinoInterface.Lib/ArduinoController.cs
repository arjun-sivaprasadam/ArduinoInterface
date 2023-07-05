using System.IO.Ports;

namespace ArduinoInterface.Lib;

public static class ArduinoController
{
    public static SerialPort? _serialPort = null;

    private static int _baudRate = 115200;
    public static int BaudRate
    {
        get => _baudRate;
        set
        {
            if (_baudRate != value)
                _baudRate = value;
        }
    }

    private static string _port = "COM21";
    public static string Port
    {
        get => _port;
        set
        {
            if (value != _port)
                _port = value;
        }
    }

    public static void ResetPort(string? port = null, int? baudRate = null)
    {
        Port = port ?? _port;
        BaudRate = baudRate ?? _baudRate;

        _serialPort = new SerialPort(Port, BaudRate);
    }

    public static void SendLedUpdates(int row, int col, bool state)
    {
        if (_serialPort is null) ResetPort();

        LEDStateManager.UpdateLedArray(_serialPort, row - 1, col - 1, state);
    }
}
