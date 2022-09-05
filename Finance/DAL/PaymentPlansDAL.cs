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
    public static class PaymentPlansDAL
    {
        public static String Insert(PaymentPlan item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfPaymentAllowed.ToString()))
                return String.Format("NoOfPaymentAllowed {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Applicable.ToString()))
                return String.Format("Applicable {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.PaymentPlans.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(PaymentPlan item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfPaymentAllowed.ToString()))
                return String.Format("NoOfPaymentAllowed {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Applicable.ToString()))
                return String.Format("Applicable {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.PaymentPlans.AddObject(item);
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
                    var del = (from item in context.PaymentPlans where (item.Code == Code) select item).FirstOrDefault();
                    context.PaymentPlans.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(PaymentPlan item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPPaymentPlansDelete]" })
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
        public static List<PaymentPlan> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<PaymentPlan> objs = new List<PaymentPlan>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPPaymentPlansSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        PaymentPlan items = new PaymentPlan
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            NoOfPaymentAllowed = item.NoOfPaymentAllowed,
                            DateX = item.DateX,
                            StatusCode = item.StatusCode,
                            Applicable = item.Applicable,
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
                        var items = context.SPPaymentPlansSelect(Code, UniversityCode, Deleted);
                        foreach (PaymentPlan item in items)
                        {
                            PaymentPlan x = new PaymentPlan
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                NoOfPaymentAllowed = item.NoOfPaymentAllowed,
                                DateX = item.DateX,
                                StatusCode = item.StatusCode,
                                Applicable = item.Applicable,
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
                return new List<PaymentPlan>();
            }
        }
    }
}
