using System.Linq;
using System.Windows;

namespace StudentListApp
{
  /// <summary>
  /// Ways that StudentInfoWindow can be used.
  /// </summary>
  public enum StudentInfoWindowRole
  {
    Add,
    Edit
  }

  /// <summary>
  /// 
  /// </summary>
  public class StudentInfoWindowViewModel : BaseViewModel
  {
    /// <summary>
    /// Private fields for student's data.
    /// </summary>
    private int inputId;
    private string inputFirstName;
    private string inputLastName;
    private int inputAge;
    private Gender inputGender;

    /// <summary>
    /// Properties.
    /// WindowRole - set the window's actions roles.
    /// ConfirmStudentInfoCommand - can be used for both adding new note in list and changing existed.
    /// </summary>
    public StudentInfoWindowRole WindowRole { get; private set; } = StudentInfoWindowRole.Add;
    public RelayCommand ConfirmStudentInfoCommand { get; private set; }
    
    /// <summary>
    /// Student's info properties, binded to input fields in StudentInfoWindow (except InputId).
    /// </summary>
    public int InputId
    {
      get
      {
        return inputId;
      }
      set
      {
        inputId = value;
        OnPropertyChanged(nameof(InputId));
      }
    }
    public string InputFirstName
    {
      get
      {
        return inputFirstName;
      }
      set
      {
        inputFirstName = value;
        OnPropertyChanged(nameof(InputFirstName));
      }
    }
    public string InputLastName
    {
      get
      {
        return inputLastName;
      }
      set
      {
        inputLastName = value;
        OnPropertyChanged(nameof(InputLastName));
      }
    }
    public int InputAge
    {
      get
      {
        return inputAge;
      }
      set
      {
        inputAge = value;
        OnPropertyChanged(nameof(InputAge));
      }
    }
    public Gender InputGender
    {
      get
      {
        return inputGender;
      }
      set
      {
        inputGender = value;
        OnPropertyChanged(nameof(InputGender));
      }
    }

    /// <summary>
    /// Method that adds a new student's note to list in parent view model if input data is valid.
    /// </summary>
    private void AddStudent()
    {
      var validator = new StudentNoteValidator();

      // Not valid data messages.
      if (!validator.CheckFirstName(InputFirstName))
      {
        MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_INCORRECT_FIRSTNAME);
      }
      else if (!validator.CheckLastName(InputLastName))
      {
        MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_INCORRECT_LASTNAME);
      }
      else if (!validator.CheckAge(InputAge))
      {
        MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_INCORRECT_AGE);
      }
      // Input data is valid.
      else
      {
        Student newStudentNote = new Student(
         App.WindowService.MainWindowViewModel.StudentsData.Count,
         InputFirstName,
         InputLastName,
         InputAge,
         InputGender);

        // Check the new note for existing in list.
        // If the list doesn't contain the new note, add it to list.
        if (App.WindowService.MainWindowViewModel.StudentsData
          .FirstOrDefault(x => { return x.AreEqual(newStudentNote); }) == null)
        {
          App.WindowService.MainWindowViewModel.StudentsData.Add(newStudentNote);
          MessageBox.Show(AssemblyInfo.ADD_STUDENT_SUCCESS);
        }
        else
        {
          MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_NOTE_EXIST);
        }
      }
    }

    /// <summary>
    /// Method that edits a student's note from list in parent view model if input data is valid.
    /// </summary>
    private void EditStudent()
    {
      var validator = new StudentNoteValidator();

      // Not valid data messages.
      if (!validator.CheckFirstName(InputFirstName))
      {
        MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_INCORRECT_FIRSTNAME);
      }
      else if (!validator.CheckLastName(InputLastName))
      {
        MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_INCORRECT_LASTNAME);
      }
      else if (!validator.CheckAge(InputAge))
      {
        MessageBox.Show(AssemblyInfo.ADD_STUDENT_DENIED + AssemblyInfo.ADD_DENIED_INCORRECT_AGE);
      }
      // Input data is valid.
      else
      {
        // Finding student's note in list by Id from parent window view model.
        Student editStudent = App.WindowService.MainWindowViewModel.StudentsData.First(x => x.Id == InputId);
        int editStudentId = App.WindowService.MainWindowViewModel.StudentsData.IndexOf(editStudent);
        App.WindowService.MainWindowViewModel.StudentsData[editStudentId] = new Student(InputId, InputFirstName,
          InputLastName, InputAge, InputGender);
        MessageBox.Show(AssemblyInfo.EDIT_STUDENT_SUCCESS);
      }
    }

    #region Constructors.
    /// <summary>
    /// Simple constructor for adding mode.
    /// </summary>
    public StudentInfoWindowViewModel()
    {
      ConfirmStudentInfoCommand = new RelayCommand(AddStudent);
    }

    /// <summary>
    /// Constructor for editting mode.
    /// </summary>
    /// <param name="role">Sets the role of the window's actions.</param>
    /// <param name="studentInfo">Info about target student.</param>
    public StudentInfoWindowViewModel(StudentInfoWindowRole role, Student studentInfo)
    {
      // Set command action according to window role.
      ConfirmStudentInfoCommand = role == StudentInfoWindowRole.Add ? new RelayCommand(AddStudent)
                                                                    : new RelayCommand(EditStudent);
      // Set up input fields with target student's info when window opens.
      InputId = studentInfo.Id;
      InputFirstName = studentInfo.FirstName;
      InputLastName = studentInfo.LastName;
      InputAge = studentInfo.Age;
      InputGender = studentInfo.Gender;
    }
    #endregion
  }
}
