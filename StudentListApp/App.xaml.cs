using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentListApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public List<Student> LoadedStudentsData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    private App()
    {
      LoadedStudentsData = new XMLParser().LoadStudentsDataFromXML("Students.xml");
    }
  }
}
