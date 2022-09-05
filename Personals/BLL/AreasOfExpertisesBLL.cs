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
    public static class AreasOfExpertisesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(AreasOfExpertis item)
        {
            return AreasOfExpertisesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(AreasOfExpertis item)
        {
            return AreasOfExpertisesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return AreasOfExpertisesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(AreasOfExpertis item)
        {
            return AreasOfExpertisesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<AreasOfExpertis> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return AreasOfExpertisesDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
