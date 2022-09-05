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
    public static class RefundsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Refund item)
        {
            return RefundsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Refund item)
        {
            return RefundsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return RefundsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Refund item)
        {
            return RefundsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Refund> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return RefundsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
