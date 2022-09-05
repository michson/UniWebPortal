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
    public static class DesignationsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Designation item)
        {
            return DesignationsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Designation item)
        {
            return DesignationsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return DesignationsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Designation item)
        {
            return DesignationsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Designation> Retrieve(Int64 Code, String StaffCode, Boolean Deleted)
        {
            return DesignationsDAL.Retrieve(Code, StaffCode, Deleted);
        }
    }
}
