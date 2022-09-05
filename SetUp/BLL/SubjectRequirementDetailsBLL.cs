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
    public static class SubjectRequirementDetailsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(SubjectRequirementDetail item)
        {
            return SubjectRequirementDetailsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(SubjectRequirementDetail item)
        {
            return SubjectRequirementDetailsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return SubjectRequirementDetailsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(SubjectRequirementDetail item)
        {
            return SubjectRequirementDetailsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<SubjectRequirementDetail> Retrieve(Int64 Code, Boolean Deleted)
        {
            return SubjectRequirementDetailsDAL.Retrieve(Code, Deleted);
        }
    }
}
