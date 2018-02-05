using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudentListApp
{
  /// <summary>
  /// Provides convertion for Visibility attribute in TextBlock and ListView controls 
  /// from amount of members in list of students.
  /// </summary>
  public class ListVisibilityFromCountConverter : IMultiValueConverter
  {
    /// <summary>
    /// Provides convertion from amount of list's members to Visibility enum value.
    /// </summary>
    /// <param name="values">values[0] - Sender control.
    /// values[1] - Amount of members.</param>
    /// <param name="targetType">Enum.</param>
    /// <param name="parameter">Parameter.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns></returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      var sender = values[0];
      var listItemsAmount = values[1] as int?;

      if (listItemsAmount == 0)
      {
        if (sender is TextBlock)
        {
          return Visibility.Visible;
        }
        else if (sender is ListView)
        {
          return Visibility.Hidden;
        }
        else
        {
          return Visibility.Hidden;
        }
      }
      else
      {
        if (sender is TextBlock)
        {
          return Visibility.Hidden;
        }
        else if (sender is ListView)
        {
          return Visibility.Visible;
        }
        else
        {
          return Visibility.Hidden;
        }
      }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
