using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public partial class PharmacyStoreRepository
    {
        public IList<LS_DRUG_GROUP> GetDrugGroupList()
        {
            try
            {
                var query = (from p in _dataContext.LS_DRUG_GROUPs.ToList()
                             orderby p.Name
                            select p).ToList();
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LS_DRUG_GROUP GetDrugGroupInfo(int id)
        {
            try
            {
                var query = from p in _dataContext.LS_DRUG_GROUPs
                           where p.Id == id
                           select p;
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertDrugGroup(LS_DRUG_GROUP doctor)
        {
            try
            {
                doctor.Actflg = 'A';
                _dataContext.Add(doctor);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateDrugGroup(LS_DRUG_GROUP doctor)
        {
            try
            {
                _dataContext.AttachCopy<LS_DRUG_GROUP>(doctor);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteDrugGroup(int id)
        {
            try
            {
                var item = (from p in _dataContext.LS_DRUG_GROUPs where p.Id == id select p).SingleOrDefault();
                _dataContext.Delete(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangeDrugGroupStatus(int id, char actflg)
        {
            try
            {
                var item = (from p in _dataContext.LS_DRUG_GROUPs where p.Id == id select p).SingleOrDefault();
                item.Actflg = actflg;
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
