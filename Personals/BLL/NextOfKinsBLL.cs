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
    public static class NextOfKinsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(NextOfKin item)
        {
            return NextOfKinsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(NextOfKin item)
        {
            return NextOfKinsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return NextOfKinsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(NextOfKin item)
        {
            return NextOfKinsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<NextOfKin> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return NextOfKinsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
