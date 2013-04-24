using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public partial class PharmacyStoreRepository
    {
        public SY_STORE GetStoreInfo(string username)
        {
            try
            {
                var query = from p in _dataContext.SY_STOREs
                            from u in _dataContext.SY_USERs.Where(f => f.Id==p.UserId)
                            where u.UserName == username
                            select p;
                
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateStore(SY_STORE store, string username)
        {
            try
            {
                var _check = (from p in _dataContext.SY_STOREs where p.UserId == store.UserId select p).SingleOrDefault();
                if (_check != null)
                {
                    store.CopyProperties(_check);
                    _dataContext.SaveChanges();
                }
                else
                {
                    var userId = (from p in _dataContext.SY_USERs where p.UserName == username select p.Id).SingleOrDefault();
                    store.UserId = userId;
                    _dataContext.Add(store);
                    _dataContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStore(int userId)
        {
            try
            {
                var item = (from p in _dataContext.SY_STOREs where p.UserId == userId select p).SingleOrDefault();
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
