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
    public static class FeesDetailsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Fee item)
        {
            return FeesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Fee item)
        {
            return FeesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return FeesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Fee item)
        {
            return FeesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Fee> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return FeesDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
