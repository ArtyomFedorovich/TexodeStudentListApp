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
    public static List<Student> LoadedStudentsData { get; private set; }
    public static WindowService WindowService { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    private App()
    {
      try
      {
        LoadedStudentsData = new XMLParser().LoadStudentsDataFromXML("Resources/Students.xml");
        WindowService = new WindowService();
      }
      catch (Exception ex)
      {
        // Logging.        
      }
    }
  }
}
