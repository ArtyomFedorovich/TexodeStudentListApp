using System.ComponentModel;

namespace StudentListApp
{
  /// <summary>
  /// Base class for view models.
  /// </summary>
  public abstract class BaseViewModel : INotifyPropertyChanged
  {
    /// <summary>
    /// Event, invoked when custom properties are changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

    /// <summary>
    /// Helper method for view model's properties that invokes PropertyChanged.
    /// </summary>
    /// <param name="propertyName"></param>
    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
