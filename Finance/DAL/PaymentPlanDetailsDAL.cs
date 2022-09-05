using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Finance.DAL
{
    public static class PaymentPlanDetailsDAL
    {
        public static String Insert(PaymentPlanDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentPlanCode.ToString()))
                return String.Format("PaymentPlanCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountedAmount.ToString()))
                return String.Format("DiscountedAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountedPercentage.ToString()))
                return String.Format("DiscountedPercentage {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Total.ToString()))
                return String.Format("Total {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.PaymentPlanDetails.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(PaymentPlanDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentPlanCode.ToString()))
                return String.Format("PaymentPlanCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountedAmount.ToString()))
                return String.Format("DiscountedAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountedPercentage.ToString()))
                return String.Format("DiscountedPercentage {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Total.ToString()))
                return String.Format("Total {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.PaymentPlanDetails.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Int64 Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    var del = (from item in context.PaymentPlanDetails where (item.Code == Code) select item).FirstOrDefault();
                    context.PaymentPlanDetails.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(PaymentPlanDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPPaymentPlanDetailsDelete]" })
                    {
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Deleted", item.Deleted);
                        cmd.Parameters.AddWithValue("@DeletedOn", item.DeletedOn);
                        cmd.Parameters.AddWithValue("@DeletedBy", item.DeletedBy);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        return Messages.Deleted;
                    }
                }
            }
            catch (Exception ex)
            {
                return String.Format("{0}:\n{1}", ex.Message, Messages.Warning);
            }
        }
        public static List<PaymentPlanDetail> Retrieve(Int64 Code, Int64 PaymentPlanCode)
        {
            List<PaymentPlanDetail> objs = new List<PaymentPlanDetail>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(PaymentPlanCode.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPPaymentPlanDetailsSelect(Code, PaymentPlanCode).FirstOrDefault();
                        PaymentPlanDetail items = new PaymentPlanDetail
                        {
                            Code = item.Code,
                            PaymentPlanCode = item.PaymentPlanCode,
                            Description = item.Description,
                            Amount = item.Amount,
                            DiscountedAmount = item.DiscountedAmount,
                            DiscountedPercentage = item.DiscountedPercentage,
                            Total = item.Total,
                            CreatedOn = item.CreatedOn,
                            CreatedBy = item.CreatedBy,
                            ModifiedOn = item.ModifiedOn,
                            ModifiedBy = item.ModifiedBy,
                            Deleted = item.Deleted,
                            DeletedOn = item.DeletedOn,
                            DeletedBy = item.DeletedBy
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var items = context.SPPaymentPlanDetailsSelect(Code, PaymentPlanCode);
                        foreach (PaymentPlanDetail item in items)
                        {
                            PaymentPlanDetail x = new PaymentPlanDetail
                            {
                                Code = item.Code,
                                PaymentPlanCode = item.PaymentPlanCode,
                                Description = item.Description,
                                Amount = item.Amount,
                                DiscountedAmount = item.DiscountedAmount,
                                DiscountedPercentage = item.DiscountedPercentage,
                                Total = item.Total,
                                CreatedOn = item.CreatedOn,
                                CreatedBy = item.CreatedBy,
                                ModifiedOn = item.ModifiedOn,
                                ModifiedBy = item.ModifiedBy,
                                Deleted = item.Deleted,
                                DeletedOn = item.DeletedOn,
                                DeletedBy = item.DeletedBy
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<PaymentPlanDetail>();
            }
        }
    }
}
