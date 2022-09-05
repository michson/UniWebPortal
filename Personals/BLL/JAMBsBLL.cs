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
    public static class JAMBsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(JAMB item)
        {
            return JAMBsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(JAMB item)
        {
            return JAMBsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return JAMBsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(JAMB item)
        {
            return JAMBsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<JAMB> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return JAMBsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
