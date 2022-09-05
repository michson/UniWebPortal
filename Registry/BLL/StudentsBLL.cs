using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registry;
using Registry.DAL;
using System.ComponentModel;

namespace Registry.BLL
{
    [DataObject]
    public static class StudentsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Student item)
        {
            return StudentsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Student item)
        {
            return StudentsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return StudentsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Student item)
        {
            return StudentsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Student> Retrieve(Int64 Code, String UniversityCode, String MatricNo, Boolean Deleted)
        {
            return StudentsDAL.Retrieve(Code, UniversityCode, MatricNo, Deleted);
        }
    }
}
