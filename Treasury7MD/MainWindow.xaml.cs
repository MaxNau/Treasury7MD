using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Treasury7MD.Views;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Treasury7MD.ViewModels;


namespace Treasury7MD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
         /*   string filePath = @"C:\Users\Rionis\Downloads\d_10.docx";
            string file = @"C:\Users\Rionis\Downloads\dd_10.docx";
            IDictionary<String, BookmarkStart> bookmarkMap = new Dictionary<String, BookmarkStart>();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            

            byte[] byteArray = File.ReadAllBytes(file);
            File.Copy(filePath, file, true);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int) byteArray.Length);
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(file, true))
                {
                    // Change the document type to Document
                    wordDocument.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

                    // Get the MainPart of the document
                    MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                    // Get the Document Settings Part
                    DocumentSettingsPart documentSettingPart1 = mainPart.DocumentSettingsPart;

                    // Create a new attachedTemplate and specify a relationship ID
                    AttachedTemplate attachedTemplate1 = new AttachedTemplate() { Id = "relationId1" };

                    // Append the attached template to the DocumentSettingsPart
                    documentSettingPart1.Settings.Append(attachedTemplate1);

                    // Add an ExternalRelationShip of type AttachedTemplate.
                    // Specify the path of template and the relationship ID
                    documentSettingPart1.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate", new Uri(filePath, UriKind.Absolute), "relationId1");

                    // Save the document
                   

                    foreach (
                        BookmarkStart bookmarkStart in
                        wordDocument.MainDocumentPart.Document.Body.Descendants<BookmarkStart>())
                    {
                        // foreach (BookmarkStart bookmarkStart in file.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
                        //{
                        bookmarkMap[bookmarkStart.Name] = bookmarkStart;
                        
                    }

                    foreach(BookmarkStart bookmark in bookmarkMap.Values)
                        {
                        Run bookmarkText = bookmark.NextSibling<Run>();
                        if (bookmarkText != null)
                        {
                            bookmarkText.GetFirstChild<Text>().Text = "Test";
                        }
                        }

                    bookmarkMap["OName"].NextSibling<Run>().GetFirstChild<Text>().Text = "TheCorporation";
                    bookmarkMap["Territory"].NextSibling<Run>().GetFirstChild<Text>().Text = "Zone51";
                    bookmarkMap["EDRPOU"].NextSibling<Run>().GetFirstChild<Text>().Text = "123661237";
                    bookmarkMap["KOTAUU"].NextSibling<Run>().GetFirstChild<Text>().Text = "2212";
                    bookmarkMap["KOPFG"].NextSibling<Run>().GetFirstChild<Text>().Text = "12";

                    mainPart.Document.Save();
                }

          //      File.WriteAllBytes(file, stream.ToArray());
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            MessageBox.Show(elapsedMs.ToString());*/

            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DCCDirectoryView _DCCDirectoryView = new DCCDirectoryView();
            _DCCDirectoryView.Show();
        }
    }
}
