
using Treasury7MD.Model;

namespace Treasury7MD.DAL
{
    public interface ITreasuryRepository
    {
        void SaveForm7(Form7MD form);
        void SaveOrgInfo(Form7MDOrganizationInfo orgInfo);
    }
}
