using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListApp
{
  public class WindowService
  {
    public MainWindowViewModel MainWindowViewModel { get; private set; }
    public void OpenAddStudentWindow(MainWindowViewModel mainViewModel)
    {
      MainWindowViewModel = mainViewModel;
      var window = new StudentInfoWindow();
      //window.Content = addWindowViewModel;
      window.Show();
    }
    public void OpenChangeStudentWindow(MainWindowViewModel mainViewModel, Student studentData)
    {
      MainWindowViewModel = mainViewModel;
      var window = new StudentInfoWindow(StudentInfoWindowRole.Edit, studentData);
      //window.FirstNameBox.Text = studentData.FirstName;
      //window.LastNameBox.Text = studentData.LastName;
      //window.AgeBox.Text = studentData.Age.ToString();
      //window.GenderBox.SelectedItem = studentData.Gender.ToString();
      window.Show();
    }
  }
}
