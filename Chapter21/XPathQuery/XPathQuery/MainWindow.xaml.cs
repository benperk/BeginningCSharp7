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

namespace XPathQuery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDocument document;

        public MainWindow()
        {
            InitializeComponent();
            document = new XmlDocument();
            document.Load(@"C:\BeginningCSharp7\Chapter21\XML and Schemas\Elements.xml");
            Update(document.DocumentElement.SelectNodes("."));
        }
        private void Update(XmlNodeList nodes)
        {
            if (nodes == null || nodes.Count == 0)
            {
                textBlockResult.Text = "The query yielded no results";
                return;
            }
            string text = "";
            foreach (XmlNode node in nodes)
            {
                text = FormatText(node, text, "") + "\r\n";
            }
            textBlockResult.Text = text;
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

        private void buttonExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlNodeList nodes = document.DocumentElement.SelectNodes(textBoxQuery.Text);
                Update(nodes);
            }
            catch (Exception err)
            {
                textBlockResult.Text = err.Message;
            }
        }
    }
}

