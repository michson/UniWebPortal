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
    public static class AccountsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Account item)
        {
            return AccountsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Account item)
        {
            return AccountsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Decimal Code)
        {
            return AccountsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Account> Retrieve(Decimal Code, String UniversityCode)
        {
            return AccountsDAL.Retrieve(Code, UniversityCode);
        }
    }
}
