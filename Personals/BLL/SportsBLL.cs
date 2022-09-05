using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Personals;
using Personals.DAL;
using System.ComponentModel;

namespace Personals.BLL
{
    [DataObject]
    public static class SportsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Sport item)
        {
            return SportsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Sport item)
        {
            return SportsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return SportsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Sport item)
        {
            return SportsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Sport> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return SportsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
