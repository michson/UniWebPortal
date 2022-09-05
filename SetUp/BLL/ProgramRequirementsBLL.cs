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
    public static class ProgramRequirementsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(ProgramRequirement item)
        {
            return ProgramRequirementsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(ProgramRequirement item)
        {
            return ProgramRequirementsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return ProgramRequirementsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(ProgramRequirement item)
        {
            return ProgramRequirementsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ProgramRequirement> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return ProgramRequirementsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
