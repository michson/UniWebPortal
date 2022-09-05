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
    public static class EntryRequirementsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(EntryRequirement item)
        {
            return EntryRequirementsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(EntryRequirement item)
        {
            return EntryRequirementsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return EntryRequirementsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(EntryRequirement item)
        {
            return EntryRequirementsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EntryRequirement> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return EntryRequirementsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
