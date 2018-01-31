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
      var window = new AddStudentWindow();
      //window.Content = addWindowViewModel;
      window.Show();
    }
  }
}
