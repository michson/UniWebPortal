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
    public static class SubjectRequirementsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(SubjectRequirement item)
        {
            return SubjectRequirementsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(SubjectRequirement item)
        {
            return SubjectRequirementsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return SubjectRequirementsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(SubjectRequirement item)
        {
            return SubjectRequirementsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<SubjectRequirement> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return SubjectRequirementsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
