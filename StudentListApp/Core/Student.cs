using System.ComponentModel;
using System.Text;

namespace StudentListApp
{
  /// <summary>
  /// Student's gender.
  /// </summary>
  public enum Gender
  {
    Male,
    Female
  }

  /// <summary>
  /// Represents information about student.
  /// </summary>
  public class Student : INotifyPropertyChanged
  {
    /// <summary>
    /// Private fields.
    /// </summary>
    private bool isSelected;

    /// <summary>
    /// Properties.
    /// </summary>
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName { get; private set; }
    public int Age { get; private set; }
    public Gender Gender { get; private set; }

    /// <summary>
    /// Indicates if this student item is selected in list.
    /// </summary>
    public bool IsSelected
    {
      get
      {
        return isSelected;
      }
      set
      {
        isSelected = value;
        OnPropertyChanged(nameof(IsSelected));
      }
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="age"></param>
    /// <param name="gender"></param>
    public Student(int id, string firstName, string lastName, int age, Gender gender)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      FullName = new StringBuilder(firstName).Append(" ").Append(lastName).ToString();
      Age = age;
      Gender = gender;
    }

    /// <summary>
    /// INotifyChanged property event and event call method.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Check if all properties of compared students are equal.
    /// </summary>
    /// <param name="comparedStudent"></param>
    /// <returns></returns>
    public bool AreEqual(Student comparedStudent)
    {
      return FirstName == comparedStudent.FirstName &&
             LastName == comparedStudent.LastName &&
             Age == comparedStudent.Age &&
             Gender == comparedStudent.Gender;
    }
  }
}
