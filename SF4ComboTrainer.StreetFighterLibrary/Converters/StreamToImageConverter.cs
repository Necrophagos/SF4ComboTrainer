namespace SF4ComboTrainer.StreetFighterLibrary.Converters
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    public class StreamToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var imageStream = value as System.IO.Stream;
            if (imageStream != null)
            {
                BitmapImage image = new BitmapImage();
                image.StreamSource = imageStream;
                return image;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}