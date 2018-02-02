namespace StudentListApp
{
  /// <summary>
  /// Provides validation for student note fields.
  /// </summary>
  public class StudentNoteValidator
  {
    /// <summary>
    /// Check student first name for not null and not empty.
    /// </summary>
    /// <param name="firstName">Student's first name.</param>
    /// <returns></returns>
    public bool CheckFirstName(string firstName)
    {
      return (firstName != string.Empty) && (firstName != null);
    }

    /// <summary>
    /// Check student last name for not null and not empty.
    /// </summary>
    /// <param name="lastName">Student's last name.</param>
    /// <returns></returns>
    public bool CheckLastName(string lastName)
    {
      return (lastName != string.Empty) && (lastName != null);
    }

    /// <summary>
    /// Check student age for valid value between STUDENT_MIN_AGE and STUDENT_MAX_AGE.
    /// </summary>
    /// <param name="age">Student's age.</param>
    /// <returns></returns>
    public bool CheckAge(int age)
    {
      return (age >= AssemblyInfo.STUDENT_MIN_AGE) && (age <= AssemblyInfo.STUDENT_MAX_AGE);
    }
  }
}
