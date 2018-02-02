using System.Collections.Generic;
using System.Xml;

namespace StudentListApp
{
  /// <summary>
  /// Provides parsing data from XML files.
  /// </summary>
  public class XMLParser
  {
    /// <summary>
    /// Load data from XML file and convert it into list of students.
    /// </summary>
    /// <param name="filePath">Filepath of current XML file.</param>
    /// <returns>List of students described as Student class.</returns>
    public List<Student> LoadStudentsDataFromXML(string filePath)
    {
      XmlDocument document = new XmlDocument();
      document.Load(filePath);

      var students = new List<Student>();
      foreach (XmlNode node in document.DocumentElement)
      {
        students.Add(new Student(int.Parse(node.Attributes[0].Value),
                                 node["FirstName"].InnerText, 
                                 node["Last"].InnerText,
                                 int.Parse(node["Age"].InnerText), 
                                 (Gender)int.Parse(node["Gender"].InnerText)));
      }

      return students;
    }
  }
}
