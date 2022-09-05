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
    public static class HobbiesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Hobby item)
        {
            return HobbiesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Hobby item)
        {
            return HobbiesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return HobbiesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Hobby item)
        {
            return HobbiesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Hobby> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return HobbiesDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
