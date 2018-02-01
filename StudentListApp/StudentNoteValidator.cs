using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListApp
{
  public class StudentNoteValidator
  {
    public bool CheckFirstName(string firstName)
    {
      return firstName != string.Empty;
    }
    public bool CheckLastName()
    {
      return true;
    }
    public bool CheckAge()
    {
      return true;
    }
    public bool CheckGender()
    {
      return true;
    }
  }
}
