using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Personals;
using Personals.DAL;
using System.ComponentModel;

namespace Personals.BLL
{
    [DataObject]
    public static class EmploymentHistoriesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(EmploymentHistory item)
        {
            return EmploymentHistoriesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(EmploymentHistory item)
        {
            return EmploymentHistoriesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return EmploymentHistoriesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(EmploymentHistory item)
        {
            return EmploymentHistoriesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EmploymentHistory> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return EmploymentHistoriesDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
