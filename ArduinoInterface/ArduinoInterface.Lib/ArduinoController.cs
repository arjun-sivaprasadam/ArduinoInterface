namespace ArduinoInterface.Lib;

public class ArduinoController
{
    private int _baudRate;
    public int BaudRate
    {
        get => _baudRate;
        set
        {
            if (_baudRate != value)
                _baudRate = value;
        }
    }

    public ArduinoController(string port, int baudRate)
    {

    }
}
