using System.IO.Ports;

namespace ArduinoInterface.Lib;
public static class LEDStateManager
{
    private static uint[] _ledState { get; } = new uint[3];

    public static void UpdateLedArray(int row, int col, bool value)
    {
        int totalRows = 8, totalCols = 12, bitsStored = 32;
        int elements = (totalRows * totalCols) / bitsStored; //3
        int bitPos = row * totalCols + col;
        int state = value ? 1 : 0;

        int index = bitPos / bitsStored;
        int position = bitPos % bitsStored;
        _ledState[index] = (uint)(state << (position));
    }

    public static bool SendCommand(SerialPort? serialPort, ArduinoCommand command)
    {
        bool result = false;
        if (serialPort == null) return false;
        try
        {
            if (!serialPort.IsOpen) serialPort.Open();

            byte[] commandBytes = BitConverter.GetBytes((int)command);
            serialPort.Write(commandBytes, 0, commandBytes.Length);

            switch (command)
            {
                case ArduinoCommand.ArduinoLEDMatrixUpdate:
                    SendLedState(serialPort);
                    break;
                // Here you can add specific actions for other commands as well
                case ArduinoCommand.None:
                    // SendCommand2(serialPort);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            serialPort?.Close();
        }
        return result;
    }


    private static void SendLedState(SerialPort serialPort)
    {
        byte[] data = new byte[12];
        for (int i = 0; i < 3; i++)
        {
            byte[] uintBytes = BitConverter.GetBytes(_ledState[i]);
            uintBytes.CopyTo(data, i * 4);
        }

        serialPort.Write(data, 0, data.Length);
    }
}

public enum ArduinoCommand
{
    ArduinoLEDMatrixUpdate = 1,
    None = 2,
}