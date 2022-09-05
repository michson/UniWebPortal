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
    public static class ReligionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Religion item)
        {
            return ReligionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Religion item)
        {
            return ReligionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return ReligionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Religion item)
        {
            return ReligionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Religion> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return ReligionsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
