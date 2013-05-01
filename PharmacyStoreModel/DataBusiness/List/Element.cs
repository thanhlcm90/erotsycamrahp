using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public partial class PharmacyStoreRepository
    {
        public IList<LS_ELEMENT> GetElementList()
        {
            try
            {
                var query = (from p in _dataContext.LS_ELEMENTs.ToList()
                             orderby p.Name
                            select p).ToList();
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LS_ELEMENT GetElementInfo(int id)
        {
            try
            {
                var query = from p in _dataContext.LS_ELEMENTs
                           where p.Id == id
                           select p;
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertElement(LS_ELEMENT doctor)
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

        public bool UpdateElement(LS_ELEMENT doctor)
        {
            try
            {
                _dataContext.AttachCopy<LS_ELEMENT>(doctor);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteElement(int id)
        {
            try
            {
                var item = (from p in _dataContext.LS_ELEMENTs where p.Id == id select p).SingleOrDefault();
                _dataContext.Delete(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangeElementStatus(int id, char actflg)
        {
            try
            {
                var item = (from p in _dataContext.LS_ELEMENTs where p.Id == id select p).SingleOrDefault();
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
