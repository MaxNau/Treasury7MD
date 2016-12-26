using System;
using System.Collections.ObjectModel;
using Treasury7MD.DB;
using Treasury7MD.Helpers;
using Treasury7MD.Models;
using System.Linq;
using System.Windows.Input;
using Treasury7MD.Commands;
using System.Windows;

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
