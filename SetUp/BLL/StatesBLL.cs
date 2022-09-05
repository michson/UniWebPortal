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
    public static class StatesBLL 
        {
            [DataObjectMethod(DataObjectMethodType.Insert, true)]
            public static String Insert(State item) 
            {
                return StatesDAL.Insert(item);
            }
            [DataObjectMethod(DataObjectMethodType.Update, true)]
            public static String Update(State item)
            {
                return StatesDAL.Update(item);
            }
            [DataObjectMethod(DataObjectMethodType.Delete, true)]
            public static String DeletePermanently(String Code, String CountriesCode)
            {
                return StatesDAL.DeletePermanently(Code, CountriesCode);
            }
            [DataObjectMethod(DataObjectMethodType.Select, true)]
            public static List<State> Retrieve(String Code, String CountriesCode)
            {
                return StatesDAL.Retrieve(Code, CountriesCode);
            }
        }
}
