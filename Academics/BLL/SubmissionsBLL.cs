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
    public static class SubmissionsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Submission item)
        {
            return SubmissionsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Submission item)
        {
            return SubmissionsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return SubmissionsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Submission item)
        {
            return SubmissionsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Submission> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return SubmissionsDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
