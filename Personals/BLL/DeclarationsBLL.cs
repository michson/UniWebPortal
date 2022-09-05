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
    public static class DeclarationsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Declaration item)
        {
            return DeclarationsDALcs.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Declaration item)
        {
            return DeclarationsDALcs.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return DeclarationsDALcs.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Declaration item)
        {
            return DeclarationsDALcs.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Declaration> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return DeclarationsDALcs.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
