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
    public static class RecordsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Record item)
        {
            return RecordsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Record item)
        {
            return RecordsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return RecordsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Record item)
        {
            return RecordsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Record> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return RecordsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
