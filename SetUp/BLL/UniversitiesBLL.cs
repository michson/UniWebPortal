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
    public static class UniversitiesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(University item) 
        {
            return UniversitiesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(University item)
        {
            return UniversitiesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(String Code)
        {
            return UniversitiesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(University item)
        {
            return UniversitiesDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<University> Retrieve(String Code, Boolean Deleted)
        {
            return UniversitiesDAL.Retrieve(Code, Deleted);
        }
    }
}
