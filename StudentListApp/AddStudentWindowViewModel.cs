using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListApp
{
  public class AddStudentWindowViewModel : BaseViewModel
  {
    public RelayCommand AddStudentCommand { get; private set; }
    public string InputFirstName { get; }

    private void AddStudent()
    {
      var validator = new StudentNoteValidator();
      if (validator.CheckFirstName(InputFirstName))
      {

      }
    }

    public AddStudentWindowViewModel()
    {
      AddStudentCommand = new RelayCommand(AddStudent);
    }
  }
}
