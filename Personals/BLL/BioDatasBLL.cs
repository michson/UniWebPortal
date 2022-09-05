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
    public static class BioDatasBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(BioData item)
        {
            return BioDatasDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(BioData item)
        {
            return BioDatasDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(String Code)
        {
            return BioDatasDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(BioData item)
        {
            return BioDatasDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<BioData> Retrieve(String Code, String ScreenCode, Boolean Deleted)
        {
            return BioDatasDAL.Retrieve(Code, ScreenCode, Deleted);
        }
    }
}
