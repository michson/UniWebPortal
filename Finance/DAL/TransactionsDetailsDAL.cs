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
    public static class TransactionsDetailsDAL
    {
        public static String Insert(TransactionsDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.InvoiceCode.ToString()))
                return String.Format("InvoiceCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ItemDescription))
                return String.Format("ItemDescription {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Quantity.ToString()))
                return String.Format("Quantity {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Unit))
                return String.Format("Unit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UnitCost.ToString()))
                return String.Format("UnitCost {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountPercentage.ToString()))
                return String.Format("DiscountPercentage {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountAmount.ToString()))
                return String.Format("DiscountAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TaxType))
                return String.Format("TaxType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TaxValue.ToString()))
                return String.Format("TaxValue {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalCost.ToString()))
                return String.Format("TotalCost {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.TransactionsDetails.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(TransactionsDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.InvoiceCode.ToString()))
                return String.Format("InvoiceCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ItemDescription))
                return String.Format("ItemDescription {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Quantity.ToString()))
                return String.Format("Quantity {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Unit))
                return String.Format("Unit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UnitCost.ToString()))
                return String.Format("UnitCost {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountPercentage.ToString()))
                return String.Format("DiscountPercentage {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountAmount.ToString()))
                return String.Format("DiscountAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TaxType))
                return String.Format("TaxType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TaxValue.ToString()))
                return String.Format("TaxValue {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalCost.ToString()))
                return String.Format("TotalCost {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.TransactionsDetails.AddObject(item);
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
                    var del = (from item in context.TransactionsDetails where (item.Code == Code) select item).FirstOrDefault();
                    context.TransactionsDetails.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(TransactionsDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPTransactionsDetailDelete]" })
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
        public static List<TransactionsDetail> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<TransactionsDetail> objs = new List<TransactionsDetail>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPTransactionsDetailSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        TransactionsDetail items = new TransactionsDetail
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            InvoiceCode = item.InvoiceCode,
                            ItemDescription = item.ItemDescription,
                            Quantity = item.Quantity,
                            Unit = item.Unit,
                            UnitCost = item.UnitCost,
                            DiscountPercentage = item.DiscountPercentage,
                            DiscountAmount = item.DiscountAmount,
                            TaxType = item.TaxType,
                            TaxValue = item.TaxValue,
                            TotalCost = item.TotalCost,
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
                        var items = context.SPTransactionsDetailSelect(Code, UniversityCode, Deleted);
                        foreach (TransactionsDetail item in items)
                        {
                            TransactionsDetail x = new TransactionsDetail
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                InvoiceCode = item.InvoiceCode,
                                ItemDescription = item.ItemDescription,
                                Quantity = item.Quantity,
                                Unit = item.Unit,
                                UnitCost = item.UnitCost,
                                DiscountPercentage = item.DiscountPercentage,
                                DiscountAmount = item.DiscountAmount,
                                TaxType = item.TaxType,
                                TaxValue = item.TaxValue,
                                TotalCost = item.TotalCost,
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
                return new List<TransactionsDetail>();
            }
        }
    }
}
