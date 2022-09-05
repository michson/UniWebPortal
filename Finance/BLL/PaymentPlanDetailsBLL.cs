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
    public static class PaymentPlanDetailsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(PaymentPlanDetail item)
        {
            return PaymentPlanDetailsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(PaymentPlanDetail item)
        {
            return PaymentPlanDetailsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int64 Code)
        {
            return PaymentPlanDetailsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(PaymentPlanDetail item)
        {
            return PaymentPlanDetailsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<PaymentPlanDetail> Retrieve(Int64 Code, Int64 PaymentPlanCode)
        {
            return PaymentPlanDetailsDAL.Retrieve(Code, PaymentPlanCode);
        }
    }
}
