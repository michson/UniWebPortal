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
    public static class DescriptionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Description item)
        {
            return DescriptionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Description item)
        {
            return DescriptionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(String Code)
        {
            return DescriptionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Description> Retrieve(String Code, String ParametersCode)
        {
            return DescriptionsDAL.Retrieve(Code, ParametersCode);
        }
    }
}
