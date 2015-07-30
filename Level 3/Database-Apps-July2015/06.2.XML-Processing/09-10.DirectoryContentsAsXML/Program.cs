using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

class Program
{
    private const string StartDirectory = @"D:\Programming\Software-University-Courses";

    static void Main()
    {
        /*
         * Problem 9.	* XmlWriter: Directory Contents as XML
         */

        var settings = new XmlWriterSettings();
        settings.ConformanceLevel = ConformanceLevel.Document;
        settings.Encoding = Encoding.UTF8;
        settings.OmitXmlDeclaration = false;
        settings.Indent = true;

        XmlWriter writer = XmlWriter.Create("../../directory-contents-xmlwriter.xml", settings);
        writer.WriteStartDocument();

        writer.WriteStartElement("directory");
        writer.WriteAttributeString("name", StartDirectory);

        RecursiveDirectorySearchWithXmlWriter(writer, StartDirectory);
        
        writer.WriteEndElement();
        writer.WriteEndDocument();

        writer.Close();

        /*
         * Problem 10.	XElement: Directory Contents as XML
         */

        XDocument doc = new XDocument();
        
        XElement root = new XElement("directory");
        root.SetAttributeValue("name", StartDirectory);

        RecursiveDirectorySearchWithXDocument(root, StartDirectory);

        doc.Add(root);
        doc.Save("../../directory-contents-xdocument.xml");
    }


    static void RecursiveDirectorySearchWithXmlWriter(XmlWriter writer, string directory)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(directory);

        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", file.Name);
            writer.WriteEndElement();
        }

        foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
        {
            writer.WriteStartElement("directory");
            writer.WriteAttributeString("name", dir.Name);

            RecursiveDirectorySearchWithXmlWriter(writer, dir.FullName);

            writer.WriteEndElement();
        }
    }

    static void RecursiveDirectorySearchWithXDocument(XElement parentElement, string directory)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(directory);

        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            XElement fileElement = new XElement("file");
            fileElement.SetAttributeValue("name", file.Name);
            parentElement.Add(fileElement);
        }

        foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
        {
            XElement directoryElement = new XElement("directory");
            directoryElement.SetAttributeValue("name", dir.Name);


            RecursiveDirectorySearchWithXDocument(directoryElement, dir.FullName);

            parentElement.Add(directoryElement);
        }
    }
}