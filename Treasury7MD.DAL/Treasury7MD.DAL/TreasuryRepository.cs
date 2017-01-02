using System;
using Treasury7MD.Model;

namespace Treasury7MD.DAL
{
    public class TreasuryRepository : ITreasuryRepository
    {
        public void SaveForm7(Form7MD form)
        {

                using (var context = new TreasuryEntity())
                {
                    context.Forms.Add(form);

                    context.Entry(form).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            

        }
    }
}
