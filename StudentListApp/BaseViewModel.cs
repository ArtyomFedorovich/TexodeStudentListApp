using System.ComponentModel;

namespace StudentListApp
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
  }
}
