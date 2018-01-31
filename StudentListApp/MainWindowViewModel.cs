using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListApp
{
  public class MainWindowViewModel : BaseViewModel
  {
    public ObservableCollection<Student> StudentsData { get; set; }

    public RelayCommand OpenAddStudentWindowCommand { get; private set; }

    private void OpenAddStudentWindow()
    {
      App.WindowService.OpenAddStudentWindow();
    }

    public MainWindowViewModel()
    {
      StudentsData = new ObservableCollection<Student>(App.LoadedStudentsData);
      OpenAddStudentWindowCommand = new RelayCommand(OpenAddStudentWindow);
    }

  }
}
