using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
    public StudentInfoWindow(StudentInfoWindowRole role)
    {
      InitializeComponent();
      DataContext = new StudentInfoWindowViewModel(role);
    }
    public StudentInfoWindow(StudentInfoWindowRole role, Student studentInfo)
    {
      InitializeComponent();
      DataContext = new StudentInfoWindowViewModel(role, studentInfo);

    }
  }
}
