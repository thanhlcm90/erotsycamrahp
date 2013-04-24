using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public partial class PharmacyStoreRepository
    {
        public IList<SY_USER> GetUserList()
        {
            try
            {
                var list = (from p in _dataContext.SY_USERs select p);
                return list.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SY_USER GetUserInfo(int id)
        {
            try {          
                var item = from p in _dataContext.SY_USERs
                            where p.Id == id
                            select p;
                return item.SingleOrDefault();
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public SY_USER GetUserInfoFromUsername(string username)
        {
            try
            {
                var item = from p in _dataContext.SY_USERs
                           where p.UserName.ToUpper() == username.ToUpper()
                           select p;
                return item.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertUser(SY_USER user)
        {
            try
            {
                _dataContext.Add(user);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUser(SY_USER user)
        {
            try
            {
                _dataContext.AttachCopy<SY_USER>(user);
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
