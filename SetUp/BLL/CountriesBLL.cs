
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
    public static class CountriesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Country item)
        {
            return CountriesDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Country item)
        {
            return CountriesDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(String Code)
        {
            return CountriesDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Country> Retrieve(String Code)
        {
            return CountriesDAL.Retrieve(Code);
        }
    }
}
