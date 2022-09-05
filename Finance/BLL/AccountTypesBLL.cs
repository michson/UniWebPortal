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
    public static class AccountTypesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(AccountType item)
        {
            return AccountTypesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(AccountType item)
        {
            return AccountTypesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Decimal Code)
        {
            return AccountTypesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<AccountType> Retrieve(Decimal Code, String UniversityCode)
        {
            return AccountTypesDAL.Retrieve(Code, UniversityCode);
        }
    }
}
