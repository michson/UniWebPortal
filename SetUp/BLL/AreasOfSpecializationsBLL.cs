using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetUp;
using SetUp.DAL;
using System.ComponentModel;

namespace SetUp.BLL
{
    [DataObject]
    public static class AreasOfSpecializationsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(AreasOfSpecialization item)
        {
            return AreasOfSpecializationsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(AreasOfSpecialization item)
        {
            return AreasOfSpecializationsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return AreasOfSpecializationsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<AreasOfSpecialization> Retrieve(Int32 Code, String DescriptionsCode)
        {
            return AreasOfSpecializationsDAL.Retrieve(Code, DescriptionsCode);
        }
    }
}
