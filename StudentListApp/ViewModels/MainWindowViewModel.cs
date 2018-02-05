using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace StudentListApp
{
  /// <summary>
  /// View Model class for MainWindow.
  /// </summary>
  public class MainWindowViewModel : BaseViewModel
  {
    /// <summary>
    /// Private members.
    /// </summary>
    private ObservableCollection<Student> studentsData;

    /// <summary>
    /// Properties.
    /// Observable collection for storing data about students that should be viewed in MainWindow.
    /// </summary>
    public ObservableCollection<Student> StudentsData
    {
      get
      {
        return studentsData;
      }
      set
      {
        studentsData = value;
        OnPropertyChanged(nameof(StudentsData));
      }
    }

    /// <summary>
    /// Commands properties for handling events from view.
    /// </summary>
    public RelayCommand OpenAddStudentWindowCommand { get; private set; }
    public RelayCommand OpenChangeStudentWindowCommand { get; private set; }
    public RelayCommand RemoveStudentNoteCommand { get; private set; }
    public RelayCommand MultipleRemoveStudentNotesCommand { get; private set; }
    public RelayCommand CheckAllStudentNotesCommand { get; private set; }

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
    /// Method that removes all selected students in list. 
    /// </summary>
    private void MultipleRemoveStudentNotes()
    {
      var newStudentsCollection = from student in StudentsData
                                  where student.IsSelected == false
                                  select student;
      StudentsData = new ObservableCollection<Student>(newStudentsCollection);
    }

    /// <summary>
    /// Method that makes all students checked or unchecked in ListView.
    /// </summary>
    /// <param name="commandParameter">IsChecked bool? value from sender control element.</param>
    private void CheckAllStudentNotes(object commandParameter)
    {
      var isChecked = commandParameter as bool?;
      if (commandParameter != null)
      {
        foreach (var student in StudentsData)
        {
          student.IsSelected = (bool)isChecked;
        }
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
      MultipleRemoveStudentNotesCommand = new RelayCommand(MultipleRemoveStudentNotes);
      CheckAllStudentNotesCommand = new RelayCommand(CheckAllStudentNotes);
    }

  }
}
