using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registry;
using Registry.DAL;
using System.ComponentModel;

namespace Registry.BLL
{
    [DataObject]
    public static class AdmissionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Admission item)
        {
            return AdmissionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Admission item)
        {
            return AdmissionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return AdmissionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Admission item)
        {
            return AdmissionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Admission> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return AdmissionsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
