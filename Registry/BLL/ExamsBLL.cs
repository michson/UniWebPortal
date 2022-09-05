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
    public static class ExamsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Exam item)
        {
            return ExamsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Exam item)
        {
            return ExamsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return ExamsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Exam item)
        {
            return ExamsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Exam> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return ExamsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
