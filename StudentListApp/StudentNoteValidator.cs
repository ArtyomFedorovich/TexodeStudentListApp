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
      return (firstName != string.Empty) && (firstName != null);
    }
    public bool CheckLastName(string lastName)
    {
      return (lastName != string.Empty) && (lastName != null);
    }
    public bool CheckAge(int age)
    {
      return (age >= 16) && (age <= 100);
    }
    public bool CheckGender(Gender gender)
    {
      return true;
    }
  }
}
