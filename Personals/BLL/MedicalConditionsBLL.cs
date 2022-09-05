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
    public static class MedicalConditionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(MedicalCondition item)
        {
            return MedicalConditionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(MedicalCondition item)
        {
            return MedicalConditionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return MedicalConditionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(MedicalCondition item)
        {
            return MedicalConditionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<MedicalCondition> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return MedicalConditionsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
