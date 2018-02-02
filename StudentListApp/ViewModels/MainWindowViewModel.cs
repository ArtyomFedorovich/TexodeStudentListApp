using System.Collections.ObjectModel;
using System.Windows;

namespace StudentListApp
{
  /// <summary>
  /// View Model class for MainWindow.
  /// </summary>
  public class MainWindowViewModel : BaseViewModel
  {
    /// <summary>
    /// Properties.
    /// Observable collection for storing data about students that should be viewed in MainWindow.
    /// </summary>
    public ObservableCollection<Student> StudentsData { get; set; }

    /// <summary>
    /// Commands properties for handling events from view.
    /// </summary>
    public RelayCommand OpenAddStudentWindowCommand { get; private set; }
    public RelayCommand OpenChangeStudentWindowCommand { get; private set; }
    public RelayCommand RemoveStudentNoteCommand { get; private set; }

    /// <summary>
    /// Method that opens new window for inputting info about new student.
    /// </summary>
    private void OpenAddStudentWindow()
    {
      App.WindowService.OpenAddStudentWindow(this);
    }
    /// <summary>
    /// Method that opens new window for inputting info about current student.
    /// </summary>
    /// <param name="commandParameter">Target student's object for transferring info to new window.</param>
    private void OpenChangeStudentWindow(object commandParameter)
    {
      App.WindowService.OpenChangeStudentWindow(this, commandParameter as Student);
    }
    /// <summary>
    /// Method that removes target student's note from list.
    /// </summary>
    /// <param name="commandParameter">Taeget student's object.</param>
    private void RemoveStudentNote(object commandParameter)
    {
      var result = MessageBox.Show(AssemblyInfo.QUESTION_REMOVE_STUDENT, AssemblyInfo.QUESTION_REMOVE_STUDENT_HEADER,
        MessageBoxButton.YesNo);
      if (result == MessageBoxResult.Yes)
      {
        StudentsData.Remove(commandParameter as Student);
      }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public MainWindowViewModel()
    {
      StudentsData = new ObservableCollection<Student>(App.LoadedStudentsData);
      OpenAddStudentWindowCommand = new RelayCommand(OpenAddStudentWindow);
      OpenChangeStudentWindowCommand = new RelayCommand(OpenChangeStudentWindow);
      RemoveStudentNoteCommand = new RelayCommand(RemoveStudentNote);
    }

  }
}
