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
    public static class GuarantorsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Guarantor item)
        {
            return GuarantorsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Guarantor item)
        {
            return GuarantorsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return GuarantorsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Guarantor item)
        {
            return GuarantorsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Guarantor> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return GuarantorsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
