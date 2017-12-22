using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace LoopThroughXmlDocument
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string booksFile = @"C:\BeginningCSharp7\Chapter21\XML and Schema\Books.xml";

        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonLoop_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(booksFile);
            textBlockResults.Text = FormatText(document.DocumentElement as XmlNode, "", "");
        }

        private string FormatText(XmlNode node, string text, string indent)
        {
            if (node is XmlText)
            {
                text += node.Value;
                return text;
            }

            if (string.IsNullOrEmpty(indent))
                indent = "";
            else
            {
                text += "\r\n" + indent;
            }

            if (node is XmlComment)
            {
                text += node.OuterXml;
                return text;
            }

            text += "<" + node.Name;
            if (node.Attributes.Count > 0)
            {
                AddAttributes(node, ref text);
            }
            if (node.HasChildNodes)
            {
                text += ">";
                foreach (XmlNode child in node.ChildNodes)
                {
                    text = FormatText(child, text, indent + "  ");
                }
                if (node.ChildNodes.Count == 1 &&
                   (node.FirstChild is XmlText || node.FirstChild is XmlComment))
                    text += "</" + node.Name + ">";
                else
                    text += "\r\n" + indent + "</" + node.Name + ">";
            }
            else
                text += " />";
            return text;
        }

        private void AddAttributes(XmlNode node, ref string text)
        {
            foreach (XmlAttribute xa in node.Attributes)
            {
                text += " " + xa.Name + "='" + xa.Value + "'";
            }
        }

        private void buttonCreateNode_Click(object sender, RoutedEventArgs e)
        {
            // Load the XML document.
            XmlDocument document = new XmlDocument();
            document.Load(booksFile);

            // Get the root element.
            XmlElement root = document.DocumentElement;

            // Create the new nodes.
            XmlElement newBook = document.CreateElement("book");
            XmlElement newTitle = document.CreateElement("title");
            XmlElement newAuthor = document.CreateElement("author");
            XmlElement newCode = document.CreateElement("code");
            XmlText title = document.CreateTextNode("Beginning Visual C# 2012");
            XmlText author = document.CreateTextNode("Karli Watson et al");
            XmlText code = document.CreateTextNode("314418");
            XmlComment comment = document.CreateComment("The previous edition");


            // Insert the elements.
            newBook.AppendChild(comment);
            newBook.AppendChild(newTitle);
            newBook.AppendChild(newAuthor);
            newBook.AppendChild(newCode);
            newTitle.AppendChild(title);
            newAuthor.AppendChild(author);
            newCode.AppendChild(code);
            root.InsertAfter(newBook, root.LastChild);

            document.Save(booksFile);
        }

        private void buttonDeleteNode_Click(object sender, RoutedEventArgs e)
        {
            // Load the XML document.
            XmlDocument document = new XmlDocument();
            document.Load(booksFile);

            // Get the root element.
            XmlElement root = document.DocumentElement;

            // Find the node. root is the <books> tag, so its last child
            // which will be the last <book> node.
            if (root.HasChildNodes)
            {
                XmlNode book = root.LastChild;

                // Delete the child.
                root.RemoveChild(book);

                // Save the document back to disk.
                document.Save(booksFile);
            }
        }
        private void buttonConvertXMLtoJSON_Click(object sender, RoutedEventArgs e)
        {
            // Load the XML document.
            XmlDocument document = new XmlDocument();

            document.Load(booksFile);

            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(document);

            textBlockResults.Text = json;

            System.IO.File.AppendAllText(@"C:\BeginningCSharp7\Chapter21\XML and Schemas\Books.json", json);
        }
        private void buttonConvertJSONtoXML_Click(object sender, RoutedEventArgs e)
        {
            // Load the json document.
            string json = System.IO.File.ReadAllText(@"C:\BeginningCSharp7\Chapter21\XML and Schemas\Books.json");

            XmlDocument document = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json);

            textBlockResults.Text = FormatText(document.DocumentElement as XmlNode, "", "");
        }

    }
}
