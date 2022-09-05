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
    public static class PaymentPlansBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(PaymentPlan item)
        {
            return PaymentPlansDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(PaymentPlan item)
        {
            return PaymentPlansDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return PaymentPlansDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(PaymentPlan item)
        {
            return PaymentPlansDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<PaymentPlan> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            return PaymentPlansDAL.Retrieve(Code, UniversityCode, Deleted);
        }
    }
}
