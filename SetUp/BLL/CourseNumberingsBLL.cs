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
    public static class CourseNumberingsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(CourseNumbering item)
        {
            return CourseNumberingsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(CourseNumbering item)
        {
            return CourseNumberingsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return CourseNumberingsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(CourseNumbering item)
        {
            return CourseNumberingsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<CourseNumbering> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return CourseNumberingsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
