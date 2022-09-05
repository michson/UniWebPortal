using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academics;
using Academics.DAL;
using System.ComponentModel;

namespace Academics.BLL
{
    [DataObject]
    public static class FinalSignatoriesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(FinalSignatory item)
        {
            return FinalSignatoriesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(FinalSignatory item)
        {
            return FinalSignatoriesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return FinalSignatoriesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(FinalSignatory item)
        {
            return FinalSignatoriesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<FinalSignatory> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return FinalSignatoriesDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
