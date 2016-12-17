using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Treasury7MD.DB;
using Treasury7MD.Helpers;
using Treasury7MD.Models;

namespace Treasury7MD.ViewModels
{
    public class Form7MDViewModel : Models.PropertyChangedObserver
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

                Form.KEKVs.Add(new KEKV() {Indicator=i, RowCode=r, Name= (int)kekv } );
            }
            kekvs = new ObservableCollection<KEKV>(Form.KEKVs);
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
