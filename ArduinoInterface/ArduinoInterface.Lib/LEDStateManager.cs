using System.IO.Ports;

namespace ArduinoInterface.Lib;

public static class LEDStateManager
{
    private static uint[] _ledState { get; } = new uint[3];

    public static void UpdateLedArray(SerialPort? serialPort, int row, int col, bool value)
    {
        if (serialPort == null) return;
        try
        {
            if (!serialPort.IsOpen) serialPort.Open();

            Task.Run(() =>
            {
                serialPort.Write(new byte[] { (byte)row, (byte)col }, 0, 2);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            serialPort?.Close();
        }
    }
}
