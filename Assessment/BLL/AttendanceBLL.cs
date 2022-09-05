using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment;
using Assessment.DAL;
using System.ComponentModel;

namespace Assessment.BLL
{
    [DataObject]
    public static class AttendanceBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Attendance item)
        {
            return AttendanceDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Attendance item)
        {
            return AttendanceDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return AttendanceDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Attendance item)
        {
            return AttendanceDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Attendance> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return AttendanceDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
