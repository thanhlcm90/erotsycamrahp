using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public interface IPharmacyStoreRepository
    {
        void Dispose();

        #region User
        IList<SY_USER> GetUserList();
        SY_USER GetUserInfo(int id);
        SY_USER GetUserInfoFromUsername(string username);
        bool InsertUser(SY_USER user);
        bool UpdateUser(SY_USER user);
        #endregion

        #region Store
        SY_STORE GetStoreInfo(string username);
        bool UpdateStore(SY_STORE store, string username);
        bool DeleteStore(int userId);
        #endregion

        #region Doctor
        IList<LS_DOCTOR> GetDoctorList();
        LS_DOCTOR GetDoctorInfo(int id);
        bool InsertDoctor(LS_DOCTOR doctor);
        bool UpdateDoctor(LS_DOCTOR doctor);
        bool DeleteDoctor(int id);
        #endregion
    }
}
