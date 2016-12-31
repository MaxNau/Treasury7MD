using System;
using System.Collections.ObjectModel;
using Treasury7MD.DB;
using Treasury7MD.Helpers;
using Treasury7MD.Models;
using System.Linq;
using System.Windows.Input;
using Treasury7MD.Commands;
using System.Windows;
using Treasury7MD.Models.OpenXML;
using Treasury7MD.Models.DBF;

namespace Treasury7MD.ViewModels
{
    public partial class Form7MDViewModel : PropertyChangedObserver
    {
        private int menuSelectedItemIndex;
        // private ObservableCollection<KEKV> KEKVs;
        public Form7MD Form { get; set; }
        private GridLength orgInfoRowHeight;

        public ICommand SaveFormCommand { get; set; }
        public ICommand CollapseOrganizationInfoCommand { get; set; }
        public ICommand ExportToWordDocxCommand { get; set; }
        public ICommand CalculateAccountPayablesCommand { get; set; }
        public ICommand ExportToDbfCommand { get; set; }
        public ICommand HeaderCommand { get; set; }

        public Form7MDViewModel()
        {
            CurrentDeviceWidth = SystemParameters.PrimaryScreenWidth - 100;
            OrgInfoRowHeight = new GridLength(4.75, GridUnitType.Star);

            Form = new Form7MD();
            foreach (KEKV.KEKVCode kekv in Enum.GetValues(typeof(KEKV.KEKVCode)))
            {
                string i, r;
                Extensions.GetDescription(kekv, out i, out r);

                Form.KEKVs.Add(new KEKV() { Indicator = i, RowCode = r, Name = (int)kekv });
            }
            //kekvs = new ObservableCollection<KEKV>(Form.KEKVs);
            AccountsReceivable.Changed += KEKV_Changed;
            AccountsPayable.Changed9 += KEKV_Changed9;

            LoadCommands();
        }

        public void ExportToDbf(object parameter)
        {
            DbfProvider.ExportForm7ToDBF("G:/", KEKVs);
        }

        public ObservableCollection<KEKV> KEKVs
        {
            get { return Form.KEKVs; }
            set
            {
                Form.KEKVs = value;
                OnPropertyChanged("KEKVs");
            }
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
            SaveFormCommand = new RelayCommand(SaveForm);
            CollapseOrganizationInfoCommand = new RelayCommand(CollapseOrganizationInfo);
            ExportToWordDocxCommand = new RelayCommand(ExportToWordDocx);
            ExportToDbfCommand = new RelayCommand(ExportToDbf);
            CalculateAccountPayablesCommand = new RelayCommand(CalculateAccountPayables);
            HeaderCommand = new RelayCommand(method);
        }

        public void method(object o)
        {

        }
        // calculates values for summing cells
        public void CalculateAccountPayables(object parameter)
        {
            KEKV kekv = parameter as KEKV;
            kekv.AccountsPayable.AtTheEndOfTheReportingPeriod = kekv.AccountsPayable.OverdueAtTheEndOfTheReportingPeriod + kekv.AccountsPayable.DebtNotDue;
            kekv.RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod = kekv.AccountsPayable.AtTheEndOfTheReportingPeriod;
        }

        // export to Word document (Docx extension)
        private void ExportToWordDocx(object parameter)
        {
            OpenXmlProvider.ExportForm7ToWordDocx(@"C:\Users\Rionis\Downloads\dd_10.docx", KEKVs);
        }

        // hides organization info
        private void CollapseOrganizationInfo(object parameter)
        {
            if (OrgInfoRowHeight.Value > 0)
                OrgInfoRowHeight = new GridLength(0, GridUnitType.Star);
            else
                OrgInfoRowHeight = new GridLength(4.75, GridUnitType.Star);
        }

        // calculates row totals
        private void KEKV_Changed()
        {
            var totalCosts = KEKVs.FirstOrDefault(x => x.Name == 2000);

            var calcSalaryAndTaxes = KEKVs.FirstOrDefault(x => x.Name == 2100);
            var salaryAndTaxesKEKVs = KEKVs.Where(x => x.Name > 2100 & x.Name <= 2120);

            var calcGoodsAndServices = KEKVs.FirstOrDefault(x => x.Name == 2200);
            var goodsAndServicesKEKVs = KEKVs.Where(x => x.Name > 2200 & x.Name <= 2282);

            var calcUtilitiesAndEnergy = KEKVs.FirstOrDefault(x => x.Name == 2270);
            var utilitiesAndEnergy = KEKVs.Where(x => x.Name > 2270 & x.Name <= 2276);

            var calcRnD = KEKVs.FirstOrDefault(x => x.Name == 2280);
            var rnD = KEKVs.Where(x => x.Name > 2280 & x.Name <= 2282);

            var calcDebtService = KEKVs.FirstOrDefault(x => x.Name == 2400);
            var debtService = KEKVs.Where(x => x.Name > 2400 & x.Name <= 2420);

            var calcCurrTransfers = KEKVs.FirstOrDefault(x => x.Name == 2600);
            var currTransfers = KEKVs.Where(x => x.Name > 2600 & x.Name <= 2630);

            var calcSocialWelfaer = KEKVs.FirstOrDefault(x => x.Name == 2700);
            var socialWelfaer = KEKVs.Where(x => x.Name > 2700 & x.Name <= 2730);

            var calcAqustionOfCapital = KEKVs.FirstOrDefault(x => x.Name == 3100);
            var aqustionOfCapital = KEKVs.Where(x => x.Name > 3100 & x.Name <= 3160);

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

        private void KEKV_Changed9()
        {
            var totalCosts = KEKVs.FirstOrDefault(x => x.Name == 2000);

            var calcSalaryAndTaxes = KEKVs.FirstOrDefault(x => x.Name == 2100);
            var salaryAndTaxesKEKVs = KEKVs.Where(x => x.Name > 2100 & x.Name <= 2120);

            var calcGoodsAndServices = KEKVs.FirstOrDefault(x => x.Name == 2200);
            var goodsAndServicesKEKVs = KEKVs.Where(x => x.Name > 2200 & x.Name <= 2282);

            var calcUtilitiesAndEnergy = KEKVs.FirstOrDefault(x => x.Name == 2270);
            var utilitiesAndEnergy = KEKVs.Where(x => x.Name > 2270 & x.Name <= 2276);

            var calcRnD = KEKVs.FirstOrDefault(x => x.Name == 2280);
            var rnD = KEKVs.Where(x => x.Name > 2280 & x.Name <= 2282);

            var calcDebtService = KEKVs.FirstOrDefault(x => x.Name == 2400);
            var debtService = KEKVs.Where(x => x.Name > 2400 & x.Name <= 2420);

            var calcCurrTransfers = KEKVs.FirstOrDefault(x => x.Name == 2600);
            var currTransfers = KEKVs.Where(x => x.Name > 2600 & x.Name <= 2630);

            var calcSocialWelfaer = KEKVs.FirstOrDefault(x => x.Name == 2700);
            var socialWelfaer = KEKVs.Where(x => x.Name > 2700 & x.Name <= 2730);

            var calcAqustionOfCapital = KEKVs.FirstOrDefault(x => x.Name == 3100);
            var aqustionOfCapital = KEKVs.Where(x => x.Name > 3100 & x.Name <= 3160);

            AccountsReceivable.Changed9 -= KEKV_Changed9;
            calcSalaryAndTaxes.AccountsPayable.AtTheEndOfTheReportingPeriod = salaryAndTaxesKEKVs.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcGoodsAndServices.AccountsPayable.AtTheEndOfTheReportingPeriod = goodsAndServicesKEKVs.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcUtilitiesAndEnergy.AccountsPayable.AtTheEndOfTheReportingPeriod = utilitiesAndEnergy.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcRnD.AccountsPayable.AtTheEndOfTheReportingPeriod = rnD.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcDebtService.AccountsPayable.AtTheEndOfTheReportingPeriod = debtService.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcCurrTransfers.AccountsPayable.AtTheEndOfTheReportingPeriod = currTransfers.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcSocialWelfaer.AccountsPayable.AtTheEndOfTheReportingPeriod = socialWelfaer.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);
            calcAqustionOfCapital.AccountsPayable.AtTheEndOfTheReportingPeriod = aqustionOfCapital.Sum(x => x.AccountsPayable.AtTheEndOfTheReportingPeriod);

            totalCosts.AccountsPayable.AtTheEndOfTheReportingPeriod = calcSalaryAndTaxes.AccountsPayable.AtTheEndOfTheReportingPeriod +
                calcGoodsAndServices.AccountsPayable.AtTheEndOfTheReportingPeriod + calcDebtService.AccountsPayable.AtTheEndOfTheReportingPeriod +
                calcCurrTransfers.AccountsPayable.AtTheEndOfTheReportingPeriod + calcSocialWelfaer.AccountsPayable.AtTheEndOfTheReportingPeriod +
                calcAqustionOfCapital.AccountsPayable.AtTheEndOfTheReportingPeriod;
            AccountsReceivable.Changed9 += KEKV_Changed9;
        }

        // saves form to database
        private void SaveForm(object parameter)
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
                MessageBox.Show(e.Message);
            }
        }
    }

    public partial class Form7MDViewModel : PropertyChangedObserver
    {

        private double currentDeviceWidth;

        private int i;
        public void SelectionIndex(object sender, EventArgs e)
        {
            var dg = sender as System.Windows.Controls.DataGrid;
            KEKV kekv = dg.CurrentCell.Item as KEKV;
            i = KEKVs.IndexOf(kekv);
            

        }

        public void LostFocus(object sender, RoutedEventArgs e)
        {
            KEKVs[i].AccountsReceivable.AtTheEndOfTheReportingPeriod += KEKVs[i].AccountsReceivable.OverdueAtTheEndOfTheReportingPeriod;
            KEKVs[i].RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod = KEKVs[i].AccountsReceivable.AtTheEndOfTheReportingPeriod;
        }

        public double CurrentDeviceWidth
        {
            get { return currentDeviceWidth; }
            set { currentDeviceWidth = value;
                OnPropertyChanged("CurrentDeviceWidth");
            }
        }
    }
}
