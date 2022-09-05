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
    public static class TransactionsDAL
    {
        public static String Insert(Transaction item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TransactionActivityCode))
                return String.Format("TransactionActivityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.InvoiceTypeCode))
                return String.Format("InvoiceTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LpoNo.ToString()))
                return String.Format("LpoNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PoNo.ToString()))
                return String.Format("PoNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CategoryCode))
                return String.Format("CategoryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AmountPaid.ToString()))
                return String.Format("AmountPaid {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Balance.ToString()))
                return String.Format("Balance {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Total.ToString()))
                return String.Format("Total {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CompanyCode))
                return String.Format("CompanyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentStatus))
                return String.Format("PaymentStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AmountInWords.ToString()))
                return String.Format("AmountInWords {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Transactions.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Transaction item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TransactionActivityCode))
                return String.Format("TransactionActivityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.InvoiceTypeCode))
                return String.Format("InvoiceTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LpoNo.ToString()))
                return String.Format("LpoNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PoNo.ToString()))
                return String.Format("PoNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CategoryCode))
                return String.Format("CategoryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AmountPaid.ToString()))
                return String.Format("AmountPaid {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Balance.ToString()))
                return String.Format("Balance {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Total.ToString()))
                return String.Format("Total {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CompanyCode))
                return String.Format("CompanyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentStatus))
                return String.Format("PaymentStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AmountInWords.ToString()))
                return String.Format("AmountInWords {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Transactions.AddObject(item);
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
                    var del = (from item in context.Transactions where (item.Code == Code) select item).FirstOrDefault();
                    context.Transactions.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Transaction item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPTransactionsDelete]" })
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
        public static List<Transaction> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Transaction> objs = new List<Transaction>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPTransactionsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Transaction items = new Transaction
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            TransactionActivityCode = item.TransactionActivityCode,
                            InvoiceTypeCode = item.InvoiceTypeCode,
                            LpoNo = item.LpoNo,
                            PoNo = item.PoNo,
                            CategoryCode = item.CategoryCode,
                            Amount = item.Amount,
                            AmountPaid = item.AmountPaid,
                            Balance = item.Balance,
                            Total = item.Total,
                            CompanyCode = item.CompanyCode,
                            PaymentStatus = item.PaymentStatus,
                            DateX = item.DateX,
                            AmountInWords = item.AmountInWords,
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
                        var items = context.SPTransactionsSelect(Code, UniversityCode, Deleted);
                        foreach (Transaction item in items)
                        {
                            Transaction x = new Transaction
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                TransactionActivityCode = item.TransactionActivityCode,
                                InvoiceTypeCode = item.InvoiceTypeCode,
                                LpoNo = item.LpoNo,
                                PoNo = item.PoNo,
                                CategoryCode = item.CategoryCode,
                                Amount = item.Amount,
                                AmountPaid = item.AmountPaid,
                                Balance = item.Balance,
                                Total = item.Total,
                                CompanyCode = item.CompanyCode,
                                PaymentStatus = item.PaymentStatus,
                                DateX = item.DateX,
                                AmountInWords = item.AmountInWords,
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
                return new List<Transaction>();
            }
        }
    }
}
