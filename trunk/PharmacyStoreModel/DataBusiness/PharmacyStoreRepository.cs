using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public partial class PharmacyStoreRepository : IPharmacyStoreRepository
    {
        private PharmacyStoreModel _dataContext;

        public PharmacyStoreRepository()
        {
            _dataContext = new PharmacyStoreModel();
            _dataContext.Log = Console.Out;
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
