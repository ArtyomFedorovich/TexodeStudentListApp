﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentListApp
{
  public class StudentInfoWindowViewModel : BaseViewModel
  {
    private int inputId;
    private string inputFirstName;
    private string inputLastName;
    private int inputAge;
    private Gender inputGender;

    public RelayCommand AddStudentCommand { get; private set; }

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

    private void AddStudent()
    {
      var validator = new StudentNoteValidator();

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

      else
      {
        Student newStudentNote = new Student(
         App.WindowService.MainWindowViewModel.StudentsData.Count,
         InputFirstName,
         InputLastName,
         InputAge,
         InputGender);

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

    public StudentInfoWindowViewModel()
    {
      AddStudentCommand = new RelayCommand(AddStudent);
    }
  }
}