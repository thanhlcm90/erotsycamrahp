using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public partial class PharmacyStoreRepository
    {
        public IList<LS_DOCTOR> GetDoctorList()
        {
            try
            {
                var query = (from p in _dataContext.LS_DOCTORs.ToList()
                            select p).ToList();
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LS_DOCTOR GetDoctorInfo(int id)
        {
            try
            {
                var query = from p in _dataContext.LS_DOCTORs
                           where p.Id == id
                           select p;
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertDoctor(LS_DOCTOR doctor)
        {
            try
            {
                _dataContext.Add(doctor);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateDoctor(LS_DOCTOR doctor)
        {
            try
            {
                _dataContext.AttachCopy<LS_DOCTOR>(doctor);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteDoctor(int id)
        {
            try
            {
                var item = (from p in _dataContext.LS_DOCTORs where p.Id == id select p).SingleOrDefault();
                _dataContext.Delete(item);
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
