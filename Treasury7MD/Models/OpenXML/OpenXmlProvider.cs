using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Treasury7MD.Model;

namespace Treasury7MD.Models.OpenXML
{
    public class OpenXmlProvider
    {
        public static void ExportForm7ToWordDocx(string path, ObservableCollection<KEKV> KEKVs)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Templates\d_10.docx";
            string file = path;
            IDictionary<String, BookmarkStart> bookmarkMap = new Dictionary<String, BookmarkStart>();

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            byte[] byteArray = File.ReadAllBytes(file);
            File.Copy(filePath, file, true);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
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

                    foreach (BookmarkStart bookmark in bookmarkMap.Values)
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

                    var tables = mainPart.Document.Descendants<Table>().ToList();

                    var rows = tables[2].Elements<TableRow>().Where(row => row.Elements<TableCell>().Any(cell => cell.InnerText == "value")).ToList();

                    int kekvLength = KEKVs.Count;

                    for (int r = 0; r < kekvLength; r++)
                    {
                        var cells = rows[r].Elements<TableCell>();

                        GetWordTableCell(cells, 3).Text = KEKVs[r].AccountsReceivable.AtTheBeginingOfTheYear.ToString();
                        GetWordTableCell(cells, 4).Text = KEKVs[r].AccountsReceivable.AtTheEndOfTheReportingPeriod.ToString();
                        GetWordTableCell(cells, 5).Text = KEKVs[r].AccountsReceivable.OverdueAtTheEndOfTheReportingPeriod.ToString();
                        GetWordTableCell(cells, 6).Text = KEKVs[r].AccountsReceivable.WrittenOffSinceTheBeginningOfTheYear.ToString();
                        GetWordTableCell(cells, 7).Text = KEKVs[r].AccountsPayable.AtTheBeginingOfTheYear.ToString();
                        GetWordTableCell(cells, 8).Text = KEKVs[r].AccountsPayable.AtTheEndOfTheReportingPeriod.ToString();
                        GetWordTableCell(cells, 9).Text = KEKVs[r].AccountsPayable.OverdueAtTheEndOfTheReportingPeriod.ToString();
                        GetWordTableCell(cells, 10).Text = KEKVs[r].AccountsPayable.DebtNotDue.ToString();
                        GetWordTableCell(cells, 11).Text = KEKVs[r].AccountsPayable.WrittenOffSinceTheBeginningOfTheYear.ToString();
                        GetWordTableCell(cells, 12).Text = KEKVs[r].RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod.ToString();
                    }

                    mainPart.Document.Save();
                }
            }
           // watch.Stop();
           // var elapsedMs = watch.ElapsedMilliseconds;

           // MessageBox.Show(elapsedMs.ToString());
        }

        private static Text GetWordTableCell(IEnumerable<TableCell> cells, int cellIndex)
        {
            Paragraph p = cells.ElementAt(cellIndex).Elements<Paragraph>().First();
            Run run = p.Elements<Run>().FirstOrDefault();
            if (run != null)
            {
                return run.Elements<Text>().FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
