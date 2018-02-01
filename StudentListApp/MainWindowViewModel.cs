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
    public RelayCommand OpenChangeStudentWindowCommand { get; private set; }
    public RelayCommand RemoveStudentNoteCommand { get; private set; }

    private void OpenAddStudentWindow()
    {
      App.WindowService.OpenAddStudentWindow(this);
    }
    private void OpenChangeStudentWindow(object commandParameter)
    {
      App.WindowService.OpenChangeStudentWindow(this, commandParameter as Student);
    }
    private void RemoveStudentNote(object commandParameter)
    {
      StudentsData.Remove(commandParameter as Student);
    }

    public MainWindowViewModel()
    {
      StudentsData = new ObservableCollection<Student>(App.LoadedStudentsData);
      OpenAddStudentWindowCommand = new RelayCommand(OpenAddStudentWindow);
      OpenChangeStudentWindowCommand = new RelayCommand(OpenChangeStudentWindow);
      RemoveStudentNoteCommand = new RelayCommand(RemoveStudentNote);
    }

  }
}
