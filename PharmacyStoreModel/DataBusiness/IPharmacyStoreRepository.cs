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
        bool ChangeDoctorStatus(int id, char actflg);
        #endregion

        #region DrugGroup
        IList<LS_DRUG_GROUP> GetDrugGroupList();
        LS_DRUG_GROUP GetDrugGroupInfo(int id);
        bool InsertDrugGroup(LS_DRUG_GROUP doctor);
        bool UpdateDrugGroup(LS_DRUG_GROUP doctor);
        bool DeleteDrugGroup(int id);
        bool ChangeDrugGroupStatus(int id, char actflg);
        #endregion

        #region Element
        IList<LS_ELEMENT> GetElementList();
        LS_ELEMENT GetElementInfo(int id);
        bool InsertElement(LS_ELEMENT doctor);
        bool UpdateElement(LS_ELEMENT doctor);
        bool DeleteElement(int id);
        bool ChangeElementStatus(int id, char actflg);
        #endregion
    }
}
