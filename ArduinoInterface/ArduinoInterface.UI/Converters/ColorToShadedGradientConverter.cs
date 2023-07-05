namespace ArduinoInterface.UI.Converters;
public class ColorToShadedGradientConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Color color)
        {
            double shadeFactor = parameter != null ? double.Parse(parameter as string) : 0.7;
            Color shadedColor = Color.FromArgb(color.A, (byte)(color.R * shadeFactor), (byte)(color.G * shadeFactor), (byte)(color.B * shadeFactor));

            return new LinearGradientBrush(new GradientStopCollection
            {
                new GradientStop(color, 0.0),
                new GradientStop(shadedColor, 1.0)
            });
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

