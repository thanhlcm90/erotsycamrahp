using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStoreModel
{
    public partial class PharmacyStoreRepository : IPharmacyStoreRepository
    {
        private PharmacyStoreModel _dataContext;

        public PharmacyStoreRepository()
        {
            _dataContext = new PharmacyStoreModel();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
