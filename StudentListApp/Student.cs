using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListApp
{
  public enum Gender
  {
    Male,
    Female
  }

  public class Student
  {
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public Gender Gender { get; private set; }

    public Student(int id, string firstName, string lastName, int age, Gender gender)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Age = age;
      Gender = gender;
    }

    public bool AreEqual(Student comparedStudent)
    {
      return FirstName == comparedStudent.FirstName &&
             LastName == comparedStudent.LastName &&
             Age == comparedStudent.Age &&
             Gender == comparedStudent.Gender;
    }
  }
}
