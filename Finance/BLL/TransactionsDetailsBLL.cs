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
    public static class TransactionsDetailsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(TransactionsDetail item)
        {
            return TransactionsDetailsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(TransactionsDetail item)
        {
            return TransactionsDetailsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return TransactionsDetailsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(TransactionsDetail item)
        {
            return TransactionsDetailsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<TransactionsDetail> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return TransactionsDetailsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
