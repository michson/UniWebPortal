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
    public static class ApprovalsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Approval item)
        {
            return ApprovalsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Approval item)
        {
            return ApprovalsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Guid Code)
        {
            return ApprovalsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Approval> Retrieve(Guid Code, String UniversityCode, String ScreenCode)
        {
            return ApprovalsDAL.Retrieve(Code, UniversityCode, ScreenCode);
        }
    }
}
