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
    public static class LGAsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(LGA item) 
        {
            return LGAsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(LGA item)
        {
            return LGAsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(String Code, String StatesCode, String CountriesCode)
        {
            return LGAsDAL.DeletePermanently(Code, StatesCode, CountriesCode);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<LGA> Retrieve(String Code, String StatesCode, String CountriesCode)
        {
            return LGAsDAL.Retrieve(Code, StatesCode, CountriesCode);
        }
    }
}
