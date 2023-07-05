using System.IO.Ports;

namespace ArduinoInterface.Lib;

public static class ArduinoController
{
    public static SerialPort? _serialPort = null;

    private static int _baudRate;
    public static int BaudRate
    {
        get => _baudRate;
        set
        {
            if (_baudRate != value)
                _baudRate = value;
        }
    }

    private static string _port = "COM3";
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

    public static Task<string?> ReadLineAsync(this SerialPort serialPort, CancellationToken cancellationToken = default)
    {
        return Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (serialPort.BytesToRead > 0)
                {
                    return serialPort.ReadLine();
                }
            }

            cancellationToken.ThrowIfCancellationRequested();
            return null;
        }, cancellationToken);
    }

    public static async Task SendLedUpdates(int row, int col, bool state)
    {
        LEDStateManager.UpdateLedArray(row, col, state);
        await LEDStateManager.SendCommandAsync(_serialPort, ArduinoCommand.ArduinoLEDMatrixUpdate);
    }
}
