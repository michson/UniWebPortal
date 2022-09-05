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
    public static class CoursesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Cours item)
        {
            return CoursesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Cours item)
        {
            return CoursesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return CoursesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Cours item)
        {
            return CoursesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Cours> Retrieve(Int64 Code, String UniversityCode, Int64 FacultyCode, Int64 DepartmentCode, Boolean Deleted)
        {
            return CoursesDAL.Retrieve(Code, UniversityCode, FacultyCode, DepartmentCode, Deleted);
        }
    }
}
