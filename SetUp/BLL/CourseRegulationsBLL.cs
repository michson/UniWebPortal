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
    public static class CourseRegulationsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(CourseRegulation item)
        {
            return CourseRegulationsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(CourseRegulation item)
        {
            return CourseRegulationsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return CourseRegulationsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(CourseRegulation item)
        {
            return CourseRegulationsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<CourseRegulation> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return CourseRegulationsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
