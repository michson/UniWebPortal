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
    public static class SigningHierarchyBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(SigningHierarchy item)
        {
            return SigningHierarchyDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(SigningHierarchy item)
        {
            return SigningHierarchyDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return SigningHierarchyDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(SigningHierarchy item)
        {
            return SigningHierarchyDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<SigningHierarchy> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return SigningHierarchyDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
