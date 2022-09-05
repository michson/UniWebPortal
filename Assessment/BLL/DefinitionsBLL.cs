using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment;
using Assessment.DAL;
using System.ComponentModel;

namespace Assessment.BLL
{
    [DataObject]
    public static class DefinitionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Definition item)
        {
            return DefinitionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Definition item)
        {
            return DefinitionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return DefinitionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Definition item)
        {
            return DefinitionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Definition> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return DefinitionsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
