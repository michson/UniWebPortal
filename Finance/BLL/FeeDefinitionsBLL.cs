using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;
using Finance.DAL;
using System.ComponentModel;

namespace Finance.BLL
{
    [DataObject]
    public static class FeeDefinitionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(FeeDefinition item)
        {
            return FeeDefinitionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(FeeDefinition item)
        {
            return FeeDefinitionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(String Code)
        {
            return FeeDefinitionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<FeeDefinition> Retrieve(String Code, String UniversityCode)
        {
            return FeeDefinitionsDAL.Retrieve(Code, UniversityCode);
        }
    }
}
