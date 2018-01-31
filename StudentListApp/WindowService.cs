using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListApp
{
  public class WindowService
  {
    public void OpenAddStudentWindow(AddStudentWindowViewModel addWindowViewModel)
    {
      var window = new AddStudentWindow();
      window.Content = addWindowViewModel;
      window.Show();
    }
  }
}
