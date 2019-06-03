using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace VendorMaintenance
{
    public static class DataContext
    {
        public static PayablesDataContext payables = new PayablesDataContext();
        public static bool vendorDeleted;

        public static void GetCurrentValues()
        {
            foreach (ObjectChangeConflict objConflict
                    in payables.ChangeConflicts)
            {
                if (objConflict.MemberConflicts.Count == 0)
                    vendorDeleted = true;
                else
                {
                    objConflict.Resolve(RefreshMode.OverwriteCurrentValues);
                    vendorDeleted = false;
                }
            }
        }
    }
}
