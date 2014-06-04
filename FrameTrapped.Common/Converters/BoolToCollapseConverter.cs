namespace FrameTrapped.Common.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    public class BoolToCollapsedConverter : IValueConverter
    {
        #region IValueConverter Member

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool b;
            bool.TryParse(value.ToString(), out b);
            
            if ( b )
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}