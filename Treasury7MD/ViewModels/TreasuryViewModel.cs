

namespace Treasury7MD.ViewModels
{
    public class TreasuryViewModel
    {
      //  private ObservableCollection<DB.DepartmentalClassification> myList;
      //  private ObservableCollection<DB.UserDepartmentalClassification> myList1;

        public TreasuryViewModel()
        {
            //LoadFromDB();
        }

     /*   public ObservableCollection<DB.DepartmentalClassification> MyList
        {
            get { return myList;}
            set
            {
                myList = value;
                OnPropertyChanged("MyList");
            }
        }

        public ObservableCollection<DB.UserDepartmentalClassification> MyList1
        {
            get { return myList1; }
            set
            {
                myList1 = value;
                OnPropertyChanged("MyList1");
            }
        }

        private void LoadFromDB()
        {
            using (var context = new TreasuryDBEntities1())
            {
                context.DepartmentalClassifications.Load();
                MyList = context.DepartmentalClassifications.Local;
                context.UserDepartmentalClassifications.Load();
                MyList1 = context.UserDepartmentalClassifications.Local;
            }
        }

        public void AddDCC(DepartmentalClassification dc, string code)
        {
            int reciverCode = int.Parse(code);
            UserDepartmentalClassification udc = new UserDepartmentalClassification()
            {
                Code = dc.Code,
                Name = dc.Name,
                FundReciverCoder = reciverCode
            };

            DbConnection.AddDCC(udc);

            using (var context = new TreasuryDBEntities1())
            {
                context.UserDepartmentalClassifications.Load();
                MyList1 = context.UserDepartmentalClassifications.Local;
            }
        }

        public void RemoveDCC(UserDepartmentalClassification udc)
        {
            using (var context = new TreasuryDBEntities1())
            {
                var item = context.UserDepartmentalClassifications.FirstOrDefault(i => i.Code == udc.Code);
                context.UserDepartmentalClassifications.Remove(item);
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
            }

            using (var context = new TreasuryDBEntities1())
            {
                context.UserDepartmentalClassifications.Load();
                MyList1 = context.UserDepartmentalClassifications.Local;
            }
        }

        public void UpdateDCC(UserDepartmentalClassification udc, string code)
        {
            int reciverCode = int.Parse(code);
            using (var context = new TreasuryDBEntities1())
            {
                var item = context.UserDepartmentalClassifications.FirstOrDefault(i => i.Code == udc.Code);
                item.FundReciverCoder = reciverCode;

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }

            using (var context = new TreasuryDBEntities1())
            {
                context.UserDepartmentalClassifications.Load();
                MyList1 = context.UserDepartmentalClassifications.Local;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }*/
    }
}
