using System;
using System.Collections.ObjectModel;
using Treasury7MD.DB;
using Treasury7MD.Helpers;
using Treasury7MD.Models;
using System.Linq;
using System.Windows.Input;
using Treasury7MD.Commands;
using System.Windows;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace Treasury7MD.ViewModels
{
    public class Form7MDViewModel : PropertyChangedObserver
    {
        private int menuSelectedItemIndex;
        private ObservableCollection<KEKV> kekvs;
        public Form7MD Form { get; set; }
        private GridLength orgInfoRowHeight;

        public ICommand SaveFormCommand { get; set; }
        public ICommand CollapseOrganizationInfoCommand { get; set; }
        public ICommand ExportToWordDocxCommand { get; set; }

        public Form7MDViewModel()
        {
            OrgInfoRowHeight = new GridLength(4.75, GridUnitType.Star);

            Form = new Form7MD();
            foreach (KEKV.KEKVCode kekv in Enum.GetValues(typeof(KEKV.KEKVCode)))
            {
                string i, r;
                Extensions.GetDescription(kekv, out i, out r);

                Form.KEKVs.Add(new KEKV() {Indicator=i, RowCode=r, Name= (int)kekv });
            }
            kekvs = new ObservableCollection<KEKV>(Form.KEKVs);
            AccountsReceivable.Changed += KEKV_Changed;

            LoadCommands();
        }

        public GridLength OrgInfoRowHeight
        {
            get { return orgInfoRowHeight; }
            set
            {
                orgInfoRowHeight = value;
                OnPropertyChanged("OrgInfoRowHeight");
            }
        }

        public int MenuSelectedItemIndex
        {
            get { return menuSelectedItemIndex; }
            set
            {
                menuSelectedItemIndex = value;
                OnPropertyChanged("MenuSelectedItemIndex");
            }
        }

        private void LoadCommands()
        {
            SaveFormCommand = new MyCommand(SaveForm, CanSaveForm);
            CollapseOrganizationInfoCommand = new MyCommand(CollapseOrganizationInfo, CanCollapseOrganizationInfo);
            ExportToWordDocxCommand = new MyCommand(ExportToWordDocx, CanExportToWordDocx);
        }

        private bool CanExportToWordDocx(object obj)
        {
            return true;
        }

        private void ExportToWordDocx()
        {
            string filePath = @"C:\Users\Rionis\Downloads\d_10.docx";
            string file = @"C:\Users\Rionis\Downloads\dd_10.docx";
            IDictionary<String, BookmarkStart> bookmarkMap = new Dictionary<String, BookmarkStart>();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here


            byte[] byteArray = File.ReadAllBytes(file);
            File.Copy(filePath, file, true);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int)byteArray.Length);
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


                        Paragraph p = cells.ElementAt(3).Elements<Paragraph>().First();
                        Run run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsReceivable.AtTheBeginingOfTheYear.ToString();
                        }

                        p = cells.ElementAt(4).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsReceivable.AtTheEndOfTheReportingPeriod.ToString();
                        }

                        p = cells.ElementAt(5).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsReceivable.OverdueAtTheEndOfTheReportingPeriod.ToString();
                        }

                        p = cells.ElementAt(6).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsReceivable.WrittenOffSinceTheBeginningOfTheYear.ToString();
                        }

                        p = cells.ElementAt(7).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsPayable.AtTheBeginingOfTheYear.ToString();
                        }

                        p = cells.ElementAt(8).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsPayable.AtTheEndOfTheReportingPeriod.ToString();
                        }

                        p = cells.ElementAt(9).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsPayable.OverdueAtTheEndOfTheReportingPeriod.ToString();
                        }

                        p = cells.ElementAt(10).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsPayable.DebtNotDue.ToString();
                        }

                        p = cells.ElementAt(11).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].AccountsPayable.WrittenOffSinceTheBeginningOfTheYear.ToString();
                        }

                        p = cells.ElementAt(12).Elements<Paragraph>().First();
                        run = p.Elements<Run>().FirstOrDefault();
                        if (run != null)
                        {
                            Text t = run.Elements<Text>().FirstOrDefault();
                            t.Text = KEKVs[r].RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod.ToString();
                        }
                    }
                    
                    

                    mainPart.Document.Save();
                }

                //      File.WriteAllBytes(file, stream.ToArray());
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            MessageBox.Show(elapsedMs.ToString());

        }

        private bool CanCollapseOrganizationInfo(object obj)
        {
            return true;
        }

        private void CollapseOrganizationInfo()
        {
            if (OrgInfoRowHeight.Value > 0)
                OrgInfoRowHeight = new GridLength(0, GridUnitType.Star);
            else
                OrgInfoRowHeight = new GridLength(4.75, GridUnitType.Star);
        }

        private bool CanSaveForm(object obj)
        {
            return true;
        }

        private void KEKV_Changed(int name, double value)
        {
            var totalCosts = kekvs.FirstOrDefault(x => x.Name == 2000);

            var calcSalaryAndTaxes = kekvs.FirstOrDefault(x => x.Name == 2100);
            var salaryAndTaxesKEKVs = kekvs.Where(x => x.Name > 2100 & x.Name <= 2120);

            var calcGoodsAndServices = kekvs.FirstOrDefault(x => x.Name == 2200);
            var goodsAndServicesKEKVs = kekvs.Where(x => x.Name > 2200 & x.Name <= 2282);

            var calcUtilitiesAndEnergy = kekvs.FirstOrDefault(x => x.Name == 2270);
            var utilitiesAndEnergy = kekvs.Where(x => x.Name > 2270 & x.Name <= 2276);

            var calcRnD = kekvs.FirstOrDefault(x => x.Name == 2280);
            var rnD = kekvs.Where(x => x.Name > 2280 & x.Name <= 2282);

            var calcDebtService = kekvs.FirstOrDefault(x => x.Name == 2400);
            var debtService = kekvs.Where(x => x.Name > 2400 & x.Name <= 2420);

            var calcCurrTransfers = kekvs.FirstOrDefault(x => x.Name == 2600);
            var currTransfers = kekvs.Where(x => x.Name > 2600 & x.Name <= 2630);

            var calcSocialWelfaer = kekvs.FirstOrDefault(x => x.Name == 2700);
            var socialWelfaer = kekvs.Where(x => x.Name > 2700 & x.Name <= 2730);

            var calcAqustionOfCapital = kekvs.FirstOrDefault(x => x.Name == 3100);
            var aqustionOfCapital = kekvs.Where(x => x.Name > 3100 & x.Name <= 3160);

            AccountsReceivable.Changed -= KEKV_Changed;
            calcSalaryAndTaxes.AccountsReceivable.AtTheBeginingOfTheYear = salaryAndTaxesKEKVs.Sum(x=>x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcGoodsAndServices.AccountsReceivable.AtTheBeginingOfTheYear = goodsAndServicesKEKVs.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcUtilitiesAndEnergy.AccountsReceivable.AtTheBeginingOfTheYear = utilitiesAndEnergy.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcRnD.AccountsReceivable.AtTheBeginingOfTheYear = rnD.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcDebtService.AccountsReceivable.AtTheBeginingOfTheYear = debtService.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcCurrTransfers.AccountsReceivable.AtTheBeginingOfTheYear = currTransfers.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcSocialWelfaer.AccountsReceivable.AtTheBeginingOfTheYear = socialWelfaer.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcAqustionOfCapital.AccountsReceivable.AtTheBeginingOfTheYear = aqustionOfCapital.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);

            totalCosts.AccountsReceivable.AtTheBeginingOfTheYear = calcSalaryAndTaxes.AccountsReceivable.AtTheBeginingOfTheYear +
                calcGoodsAndServices.AccountsReceivable.AtTheBeginingOfTheYear + calcDebtService.AccountsReceivable.AtTheBeginingOfTheYear +
                calcCurrTransfers.AccountsReceivable.AtTheBeginingOfTheYear + calcSocialWelfaer.AccountsReceivable.AtTheBeginingOfTheYear +
                calcAqustionOfCapital.AccountsReceivable.AtTheBeginingOfTheYear;
            AccountsReceivable.Changed += KEKV_Changed;
        }

        public ObservableCollection<KEKV> KEKVs
        {
            get { return kekvs; }
            set { kekvs = value;
                OnPropertyChanged("KEKVs"); 
            }
        }

        private void SaveForm()
        {
           try {
                using (var context = new TreasuryEntity())
                {
                    context.Forms.Add(Form);

                    context.Entry(Form).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
    }
}
