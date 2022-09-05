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
    public static class ProgramsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Program item)
        {
            return ProgramsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Program item)
        {
            return ProgramsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return ProgramsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Program item)
        {
            return ProgramsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Program> Retrieve(Int64 Code, String UniversityCode, Int64 FacultyCode, Int64 DepartmentCode, Int64 CourseCode, Boolean Deleted)
        {
            return ProgramsDAL.Retrieve(Code, UniversityCode, FacultyCode, DepartmentCode, CourseCode, Deleted);
        }
    }
}
