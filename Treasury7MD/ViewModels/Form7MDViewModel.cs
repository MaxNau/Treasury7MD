using System;
using System.Collections.ObjectModel;
using Treasury7MD.DB;
using Treasury7MD.Helpers;
using Treasury7MD.Models;
using System.Linq;

namespace Treasury7MD.ViewModels
{
    public class Form7MDViewModel : PropertyChangedObserver
    {
        private ObservableCollection<KEKV> kekvs;
        public Form7MD Form { get; set; }

        public Form7MDViewModel()
        {
            Form = new Form7MD();
            foreach (KEKV.KEKVCode kekv in Enum.GetValues(typeof(KEKV.KEKVCode)))
            {
                string i, r;
                Extensions.GetDescription(kekv, out i, out r);

                Form.KEKVs.Add(new KEKV() {Indicator=i, RowCode=r, Name= (int)kekv });
            }
            kekvs = new ObservableCollection<KEKV>(Form.KEKVs);
            AccountsReceivable.Changed += KEKV_Changed;
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

            AccountsReceivable.Changed -= KEKV_Changed;
            calcSalaryAndTaxes.AccountsReceivable.AtTheBeginingOfTheYear = salaryAndTaxesKEKVs.Sum(x=>x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcGoodsAndServices.AccountsReceivable.AtTheBeginingOfTheYear = goodsAndServicesKEKVs.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcUtilitiesAndEnergy.AccountsReceivable.AtTheBeginingOfTheYear = utilitiesAndEnergy.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);
            calcRnD.AccountsReceivable.AtTheBeginingOfTheYear = rnD.Sum(x => x.AccountsReceivable.AtTheBeginingOfTheYear);

            totalCosts.AccountsReceivable.AtTheBeginingOfTheYear = calcSalaryAndTaxes.AccountsReceivable.AtTheBeginingOfTheYear +
                calcGoodsAndServices.AccountsReceivable.AtTheBeginingOfTheYear;
            AccountsReceivable.Changed += KEKV_Changed;
        }

        public ObservableCollection<KEKV> KEKVs
        {
            get { return kekvs; }
            set { kekvs = value;
                OnPropertyChanged("KEKVs"); 
            }
        }

        public void SaveForm()
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
