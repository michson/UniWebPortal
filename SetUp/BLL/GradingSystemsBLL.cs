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
    public static class GradingSystemsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(GradingSystem item)
        {
            return GradingSystemsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(GradingSystem item)
        {
            return GradingSystemsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return GradingSystemsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(GradingSystem item)
        {
            return GradingSystemsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<GradingSystem> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return GradingSystemsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
