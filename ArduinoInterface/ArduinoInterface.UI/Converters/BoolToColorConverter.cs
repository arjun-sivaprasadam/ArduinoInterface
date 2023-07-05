namespace ArduinoInterface.UI.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool val && val)
            return new SolidColorBrush(Colors.LightGreen); // On color
        else
            return new SolidColorBrush(Colors.LightGray); // Off color
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}