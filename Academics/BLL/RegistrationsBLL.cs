using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academics;
using Academics.DAL;
using System.ComponentModel;

namespace Academics.BLL
{
    [DataObject]
    public static class RegistrationsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Registration item)
        {
            return RegistrationsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Registration item)
        {
            return RegistrationsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return RegistrationsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Registration item)
        {
            return RegistrationsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Registration> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return RegistrationsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
