using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;
using Finance.DAL;
using System.ComponentModel;

namespace Finance.BLL
{
    [DataObject]
    public static class FeeAllotmentsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(FeeAllotment item)
        {
            return FeeAllotmentsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(FeeAllotment item)
        {
            return FeeAllotmentsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return FeeAllotmentsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(FeeAllotment item)
        {
            return FeeAllotmentsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<FeeAllotment> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return FeeAllotmentsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
