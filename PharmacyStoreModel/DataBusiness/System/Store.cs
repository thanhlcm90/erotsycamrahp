using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStoreModel
{
    public partial class PharmacyStoreRepository
    {
        public IList<SY_STORE> GetStoreList()
        {
            try
            {
                var query = (from p in _dataContext.SY_STOREs
                                 select new SY_STORE
                                 {
                                     Id = p.Id,
                                     StoreName = p.StoreName,
                                     StoreAddress = p.StoreAddress,
                                     Email = p.Email,
                                     OwnerFullname = p.SY_USER.Fullname,
                                     StoreFax = p.StoreFax,
                                     StoreTaxNo = p.StoreTaxNo,
                                     StoreTelephone = p.StoreTelephone,
                                     Website = p.Website
                                 });
                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SY_STORE GetStoreInfo(int id)
        {
            try {
                var query = from p in _dataContext.SY_STOREs
                            where p.Id == id
                            select p;
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public bool InsertStore(SY_STORE store) {
            try {
                _dataContext.Add(store);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateStore(SY_STORE store)
        {
            try
            {
                _dataContext.AttachCopy<SY_STORE>(store);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStore(int id)
        {
            try
            {
                var item = (from p in _dataContext.SY_STOREs where p.Id==id select p).SingleOrDefault();
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
