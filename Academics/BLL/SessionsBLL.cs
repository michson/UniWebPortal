using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academics;
using Academics.DAL;
using System.ComponentModel;

namespace Academics.BLL
{
    [DataObject]
    public static class SessionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Session item)
        {
            return SessionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Session item)
        {
            return SessionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return SessionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Session item)
        {
            return SessionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Session> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return SessionsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
