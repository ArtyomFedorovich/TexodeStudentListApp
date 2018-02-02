using System.Windows;

namespace StudentListApp
{
  /// <summary>
  /// Логика взаимодействия для AddStudentWindow.xaml
  /// </summary>
  public partial class StudentInfoWindow : Window
  {
    public StudentInfoWindow()
    {
      InitializeComponent();
      DataContext = new StudentInfoWindowViewModel();
    }
    public StudentInfoWindow(StudentInfoWindowRole role, Student studentInfo)
    {
      InitializeComponent();
      DataContext = new StudentInfoWindowViewModel(role, studentInfo);

    }
  }
}
