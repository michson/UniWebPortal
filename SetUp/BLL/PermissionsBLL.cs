using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetUp;
using SetUp.DAL;
using System.ComponentModel;

namespace SetUp.BLL
{
    [DataObject]
    public static class PermissionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Permission item)
        {
            return PermissionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Permission item)
        {
            return PermissionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return PermissionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Permission item)
        {
            return PermissionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Permission> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return PermissionsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
