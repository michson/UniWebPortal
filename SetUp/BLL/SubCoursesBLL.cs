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
    public static class SubCoursesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(SubCours item)
        {
            return SubCoursesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(SubCours item)
        {
            return SubCoursesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return SubCoursesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(SubCours item)
        {
            return SubCoursesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<SubCours> Retrieve(Int64 Code, String UniversityCode, Int64 FacultyCode, Int64 DepartmentCode, Int64 CourseCode, Int64 ProgramCode, String SemesterCode, Int64 LevelCode, Boolean Deleted)
        {
            return SubCoursesDAL.Retrieve(Code, UniversityCode, FacultyCode, DepartmentCode, CourseCode, ProgramCode, SemesterCode, LevelCode, Deleted);
        }
    }
}
