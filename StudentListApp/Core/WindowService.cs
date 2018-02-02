namespace StudentListApp
{
  /// <summary>
  /// Provides methods to open and manage child windows.
  /// </summary>
  public class WindowService
  {
    /// <summary>
    /// Properties. 
    /// MainWindowViewModel - reference to main window view model for changing content in main window from child.
    /// </summary>
    public MainWindowViewModel MainWindowViewModel { get; private set; }

    /// <summary>
    /// Create child instance of StudentInfoWindow for adding a new student's note.
    /// </summary>
    /// <param name="mainViewModel">Reference to main window view model.</param>
    public void OpenAddStudentWindow(MainWindowViewModel mainViewModel)
    {
      MainWindowViewModel = mainViewModel;
      var window = new StudentInfoWindow();
      window.Show();
    }

    /// <summary>
    /// Create child instance of StudentInfoWindow for editting a student's note.
    /// </summary>
    /// <param name="mainViewModel">Reference to main window view model.</param>
    /// <param name="studentData">Current info about target student's note.</param>
    public void OpenChangeStudentWindow(MainWindowViewModel mainViewModel, Student studentData)
    {
      MainWindowViewModel = mainViewModel;
      var window = new StudentInfoWindow(StudentInfoWindowRole.Edit, studentData);
      window.Show();
    }
  }
}
