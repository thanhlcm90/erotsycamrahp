using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStoreModel
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
        IList<SY_STORE> GetStoreList();
        SY_STORE GetStoreInfo(int id);
        bool InsertStore(SY_STORE store);
        bool UpdateStore(SY_STORE store);
        bool DeleteStore(int id);
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
