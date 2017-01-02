using System;
using System.Collections.Generic;
using System.Linq;
using Treasury7MD.DAL;
using Treasury7MD.Model;

namespace Treasury7MD.ViewModels
{
    public class ProfileOverviewViewModel
    {
        private List<Form7MDOrganizationInfo> list;

        public ProfileOverviewViewModel()
        {
            list = new List<Form7MDOrganizationInfo>();
            try
            {
                using (var context = new TreasuryEntity())
                {
                    list = context.Profiles.ToList();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public List<Form7MDOrganizationInfo> List
        {
            get { return list; }
        }
    }
}
